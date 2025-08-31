using Bigbasket_Ecommerce.Models;

namespace Bigbasket_Ecommerce.Repository
{
    public interface ICardItemRepository
    {


        Task AddAsync(CartItem entity);
        void Update(CartItem entity);
        void Remove(CartItem entity);
        Task<CartItem?> GetByIdAsync(int id);
        Task<IEnumerable<CartItem>> GetAllAsync();
        Task SaveChangesAsync();

        // Extra methods for Cart specific
        Task<CartItem?> GetCartItem(int customerId, int productId);
        Task<IEnumerable<CartItem>> GetCartByCustomerId(int customerId);







    }
}
