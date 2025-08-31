using System.ComponentModel.DataAnnotations;

namespace Bigbasket_Ecommerce.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

       
       
        public int? EmployeeId { get; set; }
        public Employees? Employees { get; set; }
        
        public int UserId { get; set; }
        public  User User { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public double? TaxAmount { get; set; }

        public double TotalAmount { get; set; }
        public double SubTotal { get; set; }
        public double? Discount { get; set; }
        public double? ShippingCost { get; set; }
        public string? OrderStatus { get; set; } = "Pending";
        public string? PaymentStatus { get; set; } = "Pending";

      
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Payment>? Payments { get; set; } = new List<Payment>();
        public ICollection<Shipment>? Shipments { get; set; } = new List<Shipment>();
    }
}
