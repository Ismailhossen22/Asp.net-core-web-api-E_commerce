using Bigbasket_Ecommerce.Models;
using Bigbasket_Ecommerce.Models.Dto;
using System.Web.Mvc;

namespace Bigbasket_Ecommerce.Repository
{
    public interface IproductRepository
    {
       Task< IEnumerable<Products> > GetAllAsync();
      

        Task<Products?>  GetById(int id);
        Task< IEnumerable< ProductDto>> GetcategoryProductById(int Categoryid);

         Task AddProduct ( ProductDto productdto);
        Task Update(ProductDto productdto,int id);
        Task Delete(int id);
        void Save();


    }
}
