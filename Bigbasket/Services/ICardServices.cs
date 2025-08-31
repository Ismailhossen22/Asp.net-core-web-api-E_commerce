using Bigbasket_Ecommerce.Dto;

namespace Bigbasket_Ecommerce.Services
{
    public interface ICardServices
    {

        Task AddToCart(CardItemDto dto);
        Task<CheckoutPreviewDto> CheckoutPreview(int customerId);
        Task<OrderDto> Checkout(int customerId);

        



    }
}
