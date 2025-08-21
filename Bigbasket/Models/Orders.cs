using System.ComponentModel.DataAnnotations;

namespace Bigbasket_Ecommerce.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public int? EmployeeId { get; set; }
        public int? ShipperId { get; set; }

        public Customers? Customers { get; set; }
        public Employees? Employees { get; set; }
        public Shippers? Shippers { get; set; }
    }
}
