using System.ComponentModel.DataAnnotations;

namespace Bigbasket_Ecommerce.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public string? NormalizedName { get; set; }
        public ICollection<UserRole>? UserRole { get; set; }



    }
}
