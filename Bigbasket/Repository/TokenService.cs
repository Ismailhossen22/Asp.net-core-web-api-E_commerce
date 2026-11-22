using Azure;
using Bigbasket_Ecommerce.Data;
using Bigbasket_Ecommerce.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Bigbasket_Ecommerce.Repository
{
    public class TokenService
    {
        public readonly AppDbContext _Context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _Configuration;

        public TokenService(AppDbContext context,
            IConfiguration configuration,
             IHttpContextAccessor httpContextAccesso

            )
        {
            _Context = context;
            _Configuration = configuration;
            _httpContextAccessor = httpContextAccesso;
        }

        public string GenerateAccessToken(User user,List<string> roles)
        {


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString())
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = _Configuration["JwtSettings:Key"];
            byte[] bytkey = Encoding.UTF8.GetBytes(key);
            var keys = new SymmetricSecurityKey(bytkey);
            var creadential = new SigningCredentials(keys, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_Configuration["JwtSettings:AccessTokenExpiryMinutes"]));


            var token = new JwtSecurityToken(
                issuer: _Configuration["JwtSettings:Key"],
                audience: _Configuration["JwtSettings:Audience"],
                claims:claims,
                signingCredentials: creadential,
                expires:expires

            );
           var strigToken = new JwtSecurityTokenHandler().WriteToken(token);
            return strigToken;
           
        }

        public string GenerateRefreshToken(int userId)
        {
            var tokenId = Guid.NewGuid().ToString();

            byte[] randomBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(randomBytes);
            var expireDays = Convert.ToInt32(_Configuration["JwtSettings:RefreshTokenExpiryDays"]);
            var expirDate = DateTime.UtcNow.AddDays(expireDays);

            var token = new RefreshToken
            {
                UserId = userId,
                TokenId = tokenId,
                RefreshUserToken = refreshToken,
                IsRevoked = false,
                Expires =expirDate
               

            };
            _Context.RefreshTokens.Add(token);

            _Context.SaveChanges();

            return refreshToken;

        }


        public RefreshToken GetRefreshToken(string refreshtoken)
        {
            return _Context.RefreshTokens.FirstOrDefault(res => res.RefreshUserToken == refreshtoken);
        }

        public void RevokeRefreshToken(string refreshToken)
        {
            var token = _Context.RefreshTokens.FirstOrDefault(res => res.RefreshUserToken == refreshToken);

            if (token != null)
            {
                _Context.RefreshTokens.Remove(token);
                _Context.SaveChanges();

            }

        }

        // Remove the SetAuthCookies method entirely, as 'Response.Cookies' is not available in this context.
        // If you need to set cookies, this should be handled in a Controller or Middleware where HttpContext is available.
        // The following code removes the method to resolve CS0117.

        public void SetAuthCookies(string accessToken, string refreshToken)
        {
            var accessMinutes = Convert.ToDouble(_Configuration["JwtSettings:AccessTokenExpiryMinutes"]);
            var refreshDays = Convert.ToInt32(_Configuration["JwtSettings:RefreshTokenExpiryDays"]);
            var response = _httpContextAccessor.HttpContext?.Response ?? throw new InvalidOperationException("HttpContext is not available.");

             response.Cookies.Append("access_token", accessToken, new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None,
                 Path = "/",
                 Expires = DateTimeOffset.UtcNow.AddMinutes(accessMinutes)
            });

           response.Cookies.Append("refresh_token", refreshToken, new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None,
                //Path = "/api/auth/refresh",
                 Path = "/",
               Expires = DateTimeOffset.UtcNow.AddDays(refreshDays)
            });
        }






        public void DeleteAuthCookies()
        {
            var response = _httpContextAccessor.HttpContext?.Response
                ?? throw new InvalidOperationException("HttpContext is not available.");

            response.Cookies.Delete("access_token", new CookieOptions
            {
                Secure = true,
                SameSite = SameSiteMode.None,
                Path = "/"
            });

            
            response.Cookies.Delete("refresh_token", new CookieOptions
            {
                Secure = true,
                SameSite = SameSiteMode.None,
                Path = "/api/Account"
            });
        }











    }
}
