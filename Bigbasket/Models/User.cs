
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bigbasket_Ecommerce.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
       
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Hashpassword { get; set; } = null!;
        public string? OtpCode { get; set; }
        public DateTime? OtpExpiry { get; set; }
        public string? Token { get; set; }
      
        public ICollection<RefreshToken>? RefreshTokens { get; set; }
        public ICollection<UserRole> UserRole { get; set; } = null!;


        public ICollection<CartItem>? CartItems { get; set; }
        public ICollection<Order>? Orders { get; set; }





    }
}
