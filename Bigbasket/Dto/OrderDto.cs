namespace Bigbasket_Ecommerce.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public double SubTotal { get; set; }
        public double? Discount { get; set; }
        public double? ShippingCost { get; set; }
        public double? Tax { get; set; }
        public IList<CardItemDto> Items { get; set; } 










    }
}
