using Bigbasket_Ecommerce.Data;

using Bigbasket_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;


namespace Bigbasket_Ecommerce.Repository
{
    public class CardItemRepository : ICardItemRepository
    {
        private readonly AppDbContext _context;

        public CardItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CartItem entity)
        {
            await _context.CartItems.AddAsync(entity);
        }

        public void Update(CartItem entity)
        {
            _context.CartItems.Update(entity);
        }

        public void Remove(CartItem entity)
        {
            _context.CartItems.Remove(entity);
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync()
        {

            return await _context.CartItems.ToListAsync();

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<CartItem?> GetByIdAsync(int id)
        {

            return await _context.CartItems.FindAsync(id);
            
           
        }

        public async Task<IEnumerable<CartItem>> GetCartByCustomerId(int customerId)
        {
            return await _context.CartItems
                .Where(c => c.UserId == customerId).ToListAsync();
        }

        public async Task<CartItem?> GetCartItem(int customerId, int productId)
        {


            return await _context.CartItems.FirstOrDefaultAsync(c => c.UserId == customerId && c.ProductId == productId);
        }

     

      

       


    }
}
