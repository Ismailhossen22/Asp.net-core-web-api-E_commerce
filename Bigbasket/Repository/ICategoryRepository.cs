using Bigbasket_Ecommerce.Models;

namespace Bigbasket_Ecommerce.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category?> > GetAllCategoryAsync();

        Task<Category?> GetById(int id);

        Task AddCategory(Category category);

        Task UpdateCategory(int id);
        Task DeleteCategory(int id);
        void Save();






    }
}
