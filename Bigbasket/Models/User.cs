using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bigbasket_Ecommerce.Models
{
    public class User
    {

        public int Id { get; set; }
       
        public string? Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
        public string? Hashpassword { get; set; }
        [NotMapped]
        public ICollection<RefreshToken>? RefreshTokens { get; set; }


    }
}
