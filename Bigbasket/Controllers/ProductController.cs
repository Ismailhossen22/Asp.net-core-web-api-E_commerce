using Bigbasket_Ecommerce.Models;
using Bigbasket_Ecommerce.Models.Dto;
using Bigbasket_Ecommerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;

namespace Bigbasket_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase

    {

        private IproductRepository _productRepository;




        public ProductController(IproductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpPost]
        [Route("AddProducts")]
        public async Task<ActionResult> AddProducts(ProductDto productdto)
        {

            await _productRepository.AddProduct(productdto);


            return Ok(" Add successfull");
        }


        [HttpGet]
        [Route("GetAllProduct")]
        [Authorize]
        public async Task<IActionResult> GetAllProduct()
        {
            var product= await _productRepository.GetAllAsync();
            if (product!=null)
            {
                return Ok(new ApiResponse<IEnumerable<Products>> { message = "data fetched successfully", status = true, Data = product });
            }
            return NotFound();
        }
        

        [HttpGet]
        [Route("GetProductById")]
      
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var productitem = await _productRepository.GetById(id);
            if (productitem == null)
            {
                return NotFound(" Id not valid against not found data>....!!!");
            }
            var productdto = new ProductDto
            {
                ProductName = productitem.ProductName,
                ProductShortName = productitem.ProductShortName,
                ProductDescription = productitem.ProductDescription,
                ProductPrice = productitem.ProductPrice,
                DelevaryTimeSpan = productitem.DelevaryTimeSpan,
                ImageFile = productitem.ImageFile,
                Category_ID = productitem.Category_ID


            };

            return Ok(productdto);

        }
        [HttpPut("{id}")]
        
        public async Task<ActionResult> UpdateProduct(int id , ProductDto productdto)
        {

            await _productRepository.Update(productdto, id);
            return Ok("update successful");
        }

        [HttpDelete("{id}") ]
        public async Task<ActionResult> DeleteProduct(int id)
        {
           await _productRepository.Delete(id);
            return Ok();
        }




        [HttpGet("{categoryId}")]
        
        public async Task<IActionResult> getCategoryProductId(int categoryId)
        {
            var data= await _productRepository.GetcategoryProductById(categoryId);
            return Ok(data);
           
        }


    }
}
