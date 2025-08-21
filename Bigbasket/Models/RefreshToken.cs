using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bigbasket_Ecommerce.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
       
        public int? UserId { get; set; }
        [Required]
        public string TokenId { get; set; } = null!;
        public DateTime Expires { get; set; }
        public bool IsRevoked { get; set; } 
        [Required]
        public string RefreshUserToken { get; set; } = null!;

 
        public User? User { get; set; }




    }
}
