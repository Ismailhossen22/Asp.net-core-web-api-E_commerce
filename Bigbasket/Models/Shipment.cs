using System.ComponentModel.DataAnnotations;

namespace Bigbasket_Ecommerce.Models
{
    public class Shipment
    {
        [Key]
        public int ShipmentId { get; set; }
        public string TrackingNumber { get; set; } = default!;
        public string Carrier { get; set; } = default!;
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public string Status { get; set; } = "Pending";

        public string? ShipperName { get; set; }
        public string? Phone { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
       
    }
}
