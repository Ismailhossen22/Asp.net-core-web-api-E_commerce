namespace Bigbasket_Ecommerce.Dto
{
    public class OrderSummaryDto
    {
        public int? OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Shipping { get; set; }
        public List<CardItemDto> Items { get; set; } = new();



    }
}
