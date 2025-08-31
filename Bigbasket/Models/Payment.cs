namespace Bigbasket_Ecommerce.Models
{
    public class Payment
    {

        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }

        public string Method { get; set; } = default!; // COD, Card, Bkash...
        public double Amount { get; set; }
        public string Status { get; set; } = "Pending";

        public Order? Order { get; set; }
    }
}
