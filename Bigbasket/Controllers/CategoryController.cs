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
            try {
                await _categoryRepository.AddCategory(category);
                return Ok(new {message="Category Product Save successful",status=true} );



            }
            catch(Exception ex)
            {
                return StatusCode(500,new ApiResponse<string>{
                    message=$"Category Item do not save database: {ex.Message} ",
                    status=false

                } );
            }
          
        }

        [HttpGet]
        [Route("GetAllCategory")]
       
        public async Task<ActionResult<Category?>> GetAllCategory()
        {

            try
            {
                var category = await _categoryRepository.GetAllCategoryAsync();

                return Ok (new ApiResponse<IEnumerable<Category>>{ message = "Get category successful",status=true,Data=category });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new
                {
                    message=$"Internal server error { ex.Message}",
                    status=false

                });
            }
         
        }

        [HttpGet]
        [Route("GetbycategoryId")]
        public async Task<ActionResult<CategoreDto?> > GetbycategoryId(int id)
        {
            try
            {
                var categoryItem = await _categoryRepository.GetById(id);
                if (categoryItem ==null)
                {
                    return NotFound(new { message = "Category product not found", status = false });
                }
                var categoryDto = new CategoreDto
                {
                    CategoryId = categoryItem!.CategoryId,
                    CategoryName = categoryItem.CategoryName
                };
                return Ok(new { message = "Get Category successful", status = true, data = categoryDto });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    message=$"internal server error:{ex.Message} ",
                    status=false
                });

            }
           
        }





    }
}
