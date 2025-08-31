namespace Bigbasket_Ecommerce.Dto
{
    public class CheckoutPreviewDto
    {
        public int CustomerId { get; set; }
        public IList<CardItemDto> CartItems { get; set; }
        public double TotalAmount { get; set; }
        public double Discound { get; set; }
        public double Shipping { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
         



    }
}
