using Bigbasket_Ecommerce.Dto;
using Bigbasket_Ecommerce.Models;
using Bigbasket_Ecommerce.Repository;
using Bigbasket_Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;

namespace Bigbasket_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase

    {

        private IproductRepository _productRepository;
        private readonly ICardServices _cardServices;



        public ProductController(IproductRepository productRepository, ICardServices cardServices)
        {
            _productRepository = productRepository;
            _cardServices = cardServices;
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
                    message = $"Something went wrong: {ex.InnerException.Message}",
                    status = false


                });

            }

        }


        [HttpGet]
        [Route("GetAllProduct")]
    
        public async Task<IActionResult> GetAllProduct(int pageNumber=1,int pageSize=5)
        {

            try
            {
                var productItem =  _productRepository.GetAllAsync( pageNumber, pageSize).OrderBy(p=>p.ProductId);

                var totalCount = await productItem.CountAsync();

                var product = await productItem.Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToListAsync();

                if (product != null)
                {
                    return Ok(new
                    {
                        message = "product fetched successfully",
                        status = true,
                        data = product,
                        TotalCount = totalCount,
                        PageNumber = pageNumber,
                        PageSize = pageSize
                        
                    });

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


        [HttpGet("GetProductById")]
         
      
        public async Task<ActionResult<ProductDto>> GetProductById(int Productid)
        {

            try {
                var productitem = await _productRepository.GetById(Productid);

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
                    CategoryId = productitem.CategoryId


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
                await _productRepository.Update(id,productdto);
                return Ok(new { message = "update successful", status = true, });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"internal server Error:{ex.InnerException.Message} ",
                    status = false

                });

            }

        }

        [HttpDelete("id") ]
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




        [HttpGet("categoryId")]
        
        public async Task<IActionResult> GetCategoryProductId(int categoryId)
        {
            try {
                var product = await _productRepository.GetcategoryProductById(categoryId);
                if (product ==null)
                {
                    return NotFound(new { message = "Not found product against Id", status = false });
                }
                return Ok(new { message = "product successful", status = true, data = product });
              

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

        // Customer Order


        //order  processing Methode Implement



        [HttpPost("AddCart")]
        public async Task<IActionResult> AddCart([FromBody] CardItemDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Invalid input data",
                    status = false
                });
            }

            try
            {
                await _cardServices.AddToCart(dto);
                return Ok(new
                {
                    message = "Cart item added successfully",
                    status = true
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"Internal Server error: {ex.Message}",  // শুধু ex.Message safe
                    status = false
                });
            }
        }

        [HttpGet("checkout-preview/{customerId}")]
        public async Task<IActionResult> CheckoutPreview(int customerId )
        {
            try
            {
                var cardItem = await _cardServices.CheckoutPreview(customerId);
                if (cardItem == null)
                {
                    return Ok(new { message = "CardItem not found", status = false });
                }
                return Ok(new
                {
                    message="Data fetch complete",
                         status=true,
                      data = cardItem
                });
               
            }
            catch(Exception ex)
            {
                return StatusCode(500, new
                {
                    message=$"Internal Server error={ex.InnerException?.Message } ",
                    status=false

                });
            }


            
        }
        [HttpPost("ConfirmOrder")]

        public async Task<IActionResult> ConfirmOrder(int customerId)
        {
            try
            {
               var order= await _cardServices.Checkout(customerId);
                return Ok(new
                {
                    message = "Order Confirmed Successful",
                    status = true,
                    data = order
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = $"Internal Server error: {ex.Message}",  // শুধু ex.Message safe
                    status = false
                });
            }
        }





    }
}
