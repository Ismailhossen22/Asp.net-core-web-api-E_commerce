using Bigbasket_Ecommerce.Models;
using Bigbasket_Ecommerce.Models.Dto;
using Bigbasket_Ecommerce.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bigbasket_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
        
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<ActionResult> AddCategory(Category category)
        {

            await _categoryRepository.AddCategory(category);
            return Ok("save sussessful");
        }

        [HttpGet]
        [Route("GetAllCategory")]
       
        public async Task<IEnumerable<Category?>> GetAllCategory()
        {
            var category = await _categoryRepository.GetAllCategoryAsync();
           
            

            return category;
        }

        [HttpGet]
        [Route("GetbycategoryId")]
        public async Task<ActionResult<CategoreDto?> > GetbycategoryId(int id)
        {
            var categoryItem= await _categoryRepository.GetById(id);
            var categoryDto = new CategoreDto
            {
                CategoryId=categoryItem.CategoryId,
                CategoryName = categoryItem.CategoryName
            };
            return categoryDto;
        }





    }
}
