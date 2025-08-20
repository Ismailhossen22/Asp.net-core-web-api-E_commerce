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
            try
            {
                await _productRepository.AddProduct(productdto);


                return Ok(new {message="product Add successful",status=true});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"Something went wrong: {ex.Message}",
                    status = false


                });

            }

        }


        [HttpGet]
        [Route("GetAllProduct")]
        [Authorize]
        public async Task<IActionResult> GetAllProduct()
        {

            try
            {
                var product = await _productRepository.GetAllAsync();
                if (product != null)
                {
                    return Ok(new ApiResponse<IEnumerable<Products>> { message = "data fetched successfully", status = true, Data = product });
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"Something went wrong: {ex.Message}",
                    status = false


                });

            }

        }


        [HttpGet("{id}")]
    
      
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {

            try {
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

                return Ok(new {message="get product successful",status=true,data=productdto} );
            }
            catch(Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"Something went wrong: {ex.Message}",
                    status = false


                });

            }
           

        }



        [HttpPut("{id}")]
        
        public async Task<ActionResult> UpdateProduct(int id , ProductDto productdto)
        {
            try
            {
                await _productRepository.Update(productdto, id);
                return Ok(new { message = "update successful", status = true, });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"internal server Error:{ex.Message} ",
                    status = false

                });

            }

        }

        [HttpDelete("{id}") ]
        public async Task<ActionResult> DeleteProduct(int id)
        {

            try
            {
                await _productRepository.Delete(id);
                return Ok(new { message = "delete successful", status = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"internal server Error:{ex.Message} ",
                    status = false

                });

            }


        }




        [HttpGet("{categoryId}")]
        
        public async Task<IActionResult> getCategoryProductId(int categoryId)
        {
            try {
                var data = await _productRepository.GetcategoryProductById(categoryId);
                return Ok(new {message="product successful",status=true,data=data} );


            }
            catch(Exception ex)
            {
                return StatusCode(500, new
                {
                    message=$"internal server Error:{ex.Message} ",
                    status=false

                });

            }
            
        }


    }
}
