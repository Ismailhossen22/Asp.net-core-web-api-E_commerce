namespace Bigbasket_Ecommerce.Dto
{
    public class PaymentDto
    {

        public int OrderId { get; set; }
        public double Amount { get; set; }
        public string Method { get; set; } = default!;

    }
}
