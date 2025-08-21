using System.ComponentModel.DataAnnotations;

namespace Bigbasket_Ecommerce.Models
{
    public class Shippers
    {
        [Key]
        public int ShipperId { get; set; }

        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public ICollection<Orders>? Orders { get; set; }
    }
}
