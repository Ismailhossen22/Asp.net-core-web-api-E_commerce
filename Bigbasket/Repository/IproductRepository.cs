using Bigbasket_Ecommerce.Dto;

using Bigbasket_Ecommerce.Models;
using System.Web.Mvc;

namespace Bigbasket_Ecommerce.Repository
{
    public interface IproductRepository
    {
        IQueryable<Product>  GetAllAsync(int pageNumber,int pageSize);
      

        Task<Product?>  GetById(int id);
        Task< IEnumerable< ProductDto>> GetcategoryProductById(int CategoryId);

         Task AddProduct ( ProductDto productdto);
        Task Update(int id, ProductDto productdto);
        Task Delete(int id);
        void Save();

        //cardService
        Task AddToCart(CardItemDto cardDto);
        Task<IEnumerable<CardItemDto>> GetCartItem(int customerId,int productId);
        Task Checkout(int customerId);

      
        void Update(CardItemDto cartItem);
    


    }
}
