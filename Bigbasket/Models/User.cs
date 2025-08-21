using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bigbasket_Ecommerce.Models
{
    public class User
    {

        public int UserId { get; set; }
       
        public string Name { get; set; }
       
        public string Email { get; set; }
       
        public string Hashpassword { get; set; }
        public string? OtpCode { get; set; }
        public DateTime? OtpExpiry { get; set; }
        public string? Token { get; set; }
      
        public ICollection<RefreshToken>? RefreshTokens { get; set; }
        public ICollection<UserRole>? UserRole { get; set; }

        

    }
}
