using Bigbasket_Ecommerce.Data;
using Bigbasket_Ecommerce.Models;
using Bigbasket_Ecommerce.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public readonly IConfiguration _Configuration;

        public TokenService(AppDbContext context, IConfiguration configuration)
        {
            _Context = context;
            _Configuration = configuration;
        }

        public string GenerateAccessToken(User user)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,"User"),
                new Claim(JwtRegisteredClaimNames.Sub,user.UserId.ToString())
            };
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




    }
}
