using Bigbasket_Ecommerce.Data;
using Bigbasket_Ecommerce.Models;
using Bigbasket_Ecommerce.Models.Dto;
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

        public AccountController(AppDbContext context, TokenService tokenService)
        {
            _Context = context;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto users)
        {
            var ExistUser =  _Context.User.FirstOrDefault(user => user.Email == users.Email);

            if (ExistUser !=null )
            {
                return NotFound(new ApiResponse<UserDto> { message = "User Already Exist",status=false,Data=null });
            }
            var user = new User
            {
                Name = users.Name,
                Email = users.Email,
                password = users.password


            };


            _Context.User.Add(user);
            _Context.SaveChanges();
            return Ok(new ApiResponse<UserDto> { message = "User Create Successful", status = true });
        }
        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] loginDto users)
        {
            var user = await _Context.User.FirstOrDefaultAsync(res => res.Email == users.Email && res.password == users.Password);

            if (user==null)
            {
                return Ok(new ApiResponse<User> { message = "User  or password Invalid", status = false,Data=null });
            }

            var userdto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name

            };

            var AccessToken = _tokenService.GenerateAccessToken(user);
            var RefreshToken = _tokenService.GenerateRefreshToken(user.Id);

            var tokenData = new Models.LoginResponse
            {
                AccessToken = AccessToken,
                RefreshToken = RefreshToken,
                User = userdto
            };

            return base.Ok(new ApiResponse<Models.LoginResponse> { message = "Login Successful", status = true, Data = tokenData });

        }
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var data = await _Context.User.ToListAsync();
            if (data == null || !data.Any()) return NotFound(new ApiResponse<User> { message = "Get not user", status = false });



            return Ok(new ApiResponse<IEnumerable< User>> { message = "Get all user successful", status = true, Data=data });   
        }

        [HttpPost("Refresh")]
       
        public async  Task<IActionResult> Refresh([FromBody] TokenModel model) 
        {
           
           
            var stored = await _Context.RefreshTokens.Include(res => res.user).FirstOrDefaultAsync(r => r.RefreshUserToken == model.RefreshToken);
            if (stored == null || stored.IsRevoked || stored.Expires < DateTime.UtcNow) return Unauthorized();
            
            //stored.IsRevoked = true;

            
            var NewAccessToken = _tokenService.GenerateAccessToken(stored.user);
            var NewRefreshToken = _tokenService.GenerateRefreshToken(stored.user.Id);

            //stored.IsRevoked = true;
            //_Context.SaveChangesAsync();
           //  _tokenService.RevokeRefreshToken(model.RefreshToken);

            var token = new LoginResponse
            {
                AccessToken = NewAccessToken,
                RefreshToken = NewRefreshToken,
             



            };
           

            
            return base.Ok(new ApiResponse<LoginResponse> { message = "token create successful", status = true, Data =token  });

        }

        [HttpPost("Logout") ]
        public async Task<IActionResult> Logout([FromBody] TokenModel model)
        {
            var stored = await _Context.RefreshTokens.SingleOrDefaultAsync(r => r.RefreshUserToken == model.RefreshToken);
             if(stored != null)
            {
                stored.IsRevoked = true;
               // _tokenService.RevokeRefreshToken(model.RefreshToken);
                await _Context.SaveChangesAsync();
            }
            return Ok(new ApiResponse<TokenModel> { message = "Logout successfully",status=true });
        }



    }
}
