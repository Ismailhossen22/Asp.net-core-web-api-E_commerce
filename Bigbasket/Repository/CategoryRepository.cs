using Bigbasket_Ecommerce.Data;
using Bigbasket_Ecommerce.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Bigbasket_Ecommerce.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
         
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category category)
        {
            await _context.Categorys.AddAsync(category);
            _context.SaveChanges();


        }

        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Categorys.ToListAsync();


        }

        public async Task<Category?> GetById(int id)
        {
            return await _context.Categorys.FindAsync(id);


        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
