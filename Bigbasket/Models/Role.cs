using System.ComponentModel.DataAnnotations;

namespace Bigbasket_Ecommerce.Models
{
    public class Role
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}
