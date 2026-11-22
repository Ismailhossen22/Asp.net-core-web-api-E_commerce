using Bigbasket_Ecommerce.Data;
using Bigbasket_Ecommerce.Dto;
using Bigbasket_Ecommerce.Models;

using Bigbasket_Ecommerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bigbasket_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        public readonly AppDbContext _Context;
        public readonly TokenService _tokenService;
        public readonly IEmailService _EmailService;



        public AccountController(AppDbContext context, TokenService tokenService, IEmailService emailService)
        {
            _Context = context;
            _tokenService = tokenService;
            _EmailService = emailService;

        }



        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto model)

        {

            try
            {
                var ExistUser = _Context.User.FirstOrDefault(user => user.Email == model.Email);

                if (ExistUser != null)
                {
                    return Ok(new ApiResponse<string> { message = "User Already Exist", status = false });
                }
                string HashPassword = BCrypt.Net.BCrypt.HashPassword(model.password);
                

                var user = new User
                {

                    Name = model.Name,
                    Email = model.Email,
                    Hashpassword = HashPassword


                };


                _Context.User.Add(user);
               await _Context.SaveChangesAsync();
                //Role assign
                var roleName = string.IsNullOrEmpty(model.Role) ? "User" : model.Role;
                var role = await _Context.Role.FirstOrDefaultAsync(r => r.RoleName == roleName);
                 if(role != null)
                {
                    _Context.UserRole.Add(new UserRole
                    {
                        UserId = user.UserId,
                        RoleId = role.RoleId

                    });
                    await _Context.SaveChangesAsync();
                }
              

                return Ok(new ApiResponse<string> { message = "User Create Successful", status = true });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<string>
                {

                    message = $"Internal Error :{ex.Message} ",
                    status = false

                });

            }

        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] loginDto model)
        {

            try
            {
                var user = await _Context.User.Include(u => u.UserRole)
                    .ThenInclude(ur => ur.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user == null )
                {
                    return Ok(new ApiResponse<loginDto> { message = "User  Invalid please right Email", status = false });
                }
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(model.Password, user.Hashpassword);
                if (!isValidPassword)
                {
                    return Ok(new ApiResponse<loginDto> { message = " Password Invalid!! please right password", status = false });
                }

                var userItem = new UserDto
                {
                    Id = user.UserId,
                    Email = user.Email,
                    Name = user.Name

                };
                var role = user.UserRole.Select(ur => ur.Role.RoleName).ToList() ;

                var AccessToken = _tokenService.GenerateAccessToken(user,role);
                var RefreshToken = _tokenService.GenerateRefreshToken(user.UserId);
                _tokenService.SetAuthCookies(AccessToken, RefreshToken);

                var tokenData = new LoginResponse
                {
                    AccessToken = AccessToken,
                    RefreshToken = RefreshToken,
                    User = userItem,
                    Role=role
                   
                };

                return base.Ok(new ApiResponse<LoginResponse> { message = "Login Successful", status = true, Data = tokenData });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    message = $"Server Error :{ex.Message} ",
                    status = false
                });


            }


        }


        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var data = await _Context.User.ToListAsync();
                if (data == null || !data.Any()) return NotFound(new ApiResponse<string> { message = "Get not user", status = false });



                return Ok(new ApiResponse<IEnumerable<User>> { message = "Get all user successful", status = true, Data = data });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    message = $"internal problem :{ex.Message} ",
                    status = false

                });
            }

        }


        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenModel model)
        {
            try
            {
                //var refreshToken = Request.Cookies["refresh_token"];
                //if (string.IsNullOrEmpty(refreshToken))
                //    return Unauthorized(new ApiResponse<string> { message = "Refresh token missing", status = false });



                var stored = await _Context.RefreshTokens.Include(res => res.User).FirstOrDefaultAsync(r => r.RefreshUserToken == model.RefreshToken);
                if (stored == null || stored.IsRevoked || stored.Expires < DateTime.UtcNow)
                    return Unauthorized(new ApiResponse<string> { message = "Invalid or Expired Refresh token", status = false });

                //stored.IsRevoked = true;
                       var roles = await _Context.UserRole
                   .Where(ur => ur.UserId == stored.User.UserId)
                   .Select(ur => ur.Role.RoleName)
                   .ToListAsync();

                var newAccessToken = _tokenService.GenerateAccessToken(stored.User, roles);
                var newRefreshToken = _tokenService.GenerateRefreshToken(stored.User.UserId);
                _tokenService.SetAuthCookies(newAccessToken, newRefreshToken);
                //stored.IsRevoked = true;
                //_Context.SaveChangesAsync();
                //  _tokenService.RevokeRefreshToken(model.RefreshToken);

                var token = new LoginResponse
                {
                   // AccessToken = NewAccessToken,
                    RefreshToken = newRefreshToken,

                };


                return Ok(new ApiResponse<LoginResponse>
                {
                    message = "token create successful",
                    status = true,
                    Data = token
                });


            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    message = $"Something went wrong{ex.Message} ",
                    status = false


                });
            }




        }


        //[HttpPost("Refresh")]
        //public async Task<IActionResult> Refresh()  
        //{
        //    try
        //    {
        //        var refreshToken = Request.Cookies["refresh_token"];
        //        if (string.IsNullOrEmpty(refreshToken))
        //            return Unauthorized(new ApiResponse<string> { message = "Refresh token missing", status = false });

        //        var stored = await _Context.RefreshTokens
        //            .Include(r => r.User)
        //            .FirstOrDefaultAsync(r => r.RefreshUserToken == refreshToken);

        //        if (stored == null || stored.IsRevoked || stored.Expires < DateTime.UtcNow)
        //        {
        //            _tokenService.DeleteAuthCookies();
        //            return Unauthorized(new ApiResponse<string> { message = "Invalid or Expired Refresh token", status = false });
        //        }

        //        // পুরনো token বাতিল (rotation)
        //        stored.IsRevoked = true;
        //        await _Context.SaveChangesAsync();

        //        var roles = await _Context.UserRole
        //            .Where(ur => ur.UserId == stored.UserId)
        //            .Select(ur => ur.Role.RoleName)
        //            .ToListAsync();

        //        var newAccessToken = _tokenService.GenerateAccessToken(stored.User, roles);
        //        var newRefreshToken = _tokenService.GenerateRefreshToken(stored.UserId);

        //        _tokenService.SetAuthCookies(newAccessToken, newRefreshToken);

        //        return Ok(new ApiResponse<string> { message = "Token refreshed", status = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new ApiResponse<string> { message = $"Something went wrong {ex.Message}", status = false });
        //    }
        //}










        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody] TokenModel model)
        {

            try
            {
                var stored = await _Context.RefreshTokens.SingleOrDefaultAsync(r => r.RefreshUserToken == model.RefreshToken);
                if (stored != null)
                {
                    stored.IsRevoked = true;
                    // _tokenService.RevokeRefreshToken(model.RefreshToken);
                    await _Context.SaveChangesAsync();
                }
                return Ok(new ApiResponse<TokenModel> { message = "Logout successfully", status = true });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<string>
                {
                    message = $"Logout failed:{ex.Message} ",
                    status = false

                });
            }



        }


       // [HttpPost("Logout")]
        //public async Task<IActionResult> Logout() 
        //{
        //    try
        //    {
        //        var refreshToken = Request.Cookies["refresh_token"];

        //        if (!string.IsNullOrEmpty(refreshToken))
        //        {
        //            var stored = await _Context.RefreshTokens
        //                .FirstOrDefaultAsync(r => r.RefreshUserToken == refreshToken);

        //            if (stored != null)
        //            {
        //                stored.IsRevoked = true;
        //                await _Context.SaveChangesAsync();
        //            }
        //        }

        //        _tokenService.DeleteAuthCookies();

        //        return Ok(new ApiResponse<string> { message = "Logout successfully", status = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new ApiResponse<string> { message = $"Logout failed: {ex.Message}", status = false });
        //    }
        //}











        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            try
            {
                var user = await _Context.User.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    return Ok("User not found");
                }

                var otp = new Random().Next(100000, 999999).ToString();
                user.OtpCode = otp;
                user.OtpExpiry = DateTime.UtcNow.AddMinutes(5);


                await _Context.SaveChangesAsync();

                await _EmailService.SendEmailAsync(user.Email, " Password Reset OTP! ", $" <h2> Your OTP Code is <b> {otp} </b>.It Will Expire in 5 minutes</h2> <h1> To Reset Password this OTP </h1>");



                return Ok(new { message = "Otp Sent to your email", status = true });




            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"server error : {ex.Message} ",
                    status = false
                });

            }



        }


        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            try
            {   // user email check
                var user = await _Context.User.FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user == null)
                {
                    return Ok(new { message = "User is Invalid", status = false });


                }
                //OTP check
                if (user.OtpCode != model.OtpCode || user.OtpExpiry < DateTime.UtcNow)
                {

                    return Ok(new { message = "Invalid or expired OTP", status = false });
                }
                // hashPassword save
                user.Hashpassword = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
                user.OtpCode = null;
                user.OtpExpiry = null;
                await _Context.SaveChangesAsync();

                return Ok(new { message = "Password reset successfully", status = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    messeage = $"Internal Server problem={ex.Message} ",
                    status = false

                });

            }



        }









    }


 }
