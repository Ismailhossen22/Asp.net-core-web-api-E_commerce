using Bigbasket_Ecommerce.Models.Dto;

namespace Bigbasket_Ecommerce.Models
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserDto User { get; set; }




    }
}
