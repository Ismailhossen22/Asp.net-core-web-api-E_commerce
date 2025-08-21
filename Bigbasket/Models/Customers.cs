using System.ComponentModel.DataAnnotations;
using static NuGet.Packaging.PackagingConstants;

namespace Bigbasket_Ecommerce.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string? City { get; set; }
        public int? PostalCode { get; set; }
        public string? Country { get; set; }
        public ICollection<Orders>? Orders { get; set; }


    }
}
