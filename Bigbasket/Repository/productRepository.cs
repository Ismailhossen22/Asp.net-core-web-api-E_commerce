using Bigbasket_Ecommerce.Data;
using Bigbasket_Ecommerce.Dto;
using Bigbasket_Ecommerce.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;



namespace Bigbasket_Ecommerce.Repository
{
    public class productRepository : IproductRepository
    {


        public readonly AppDbContext _context;

        public productRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddToCart(CardItemDto cardDto)
        {

            





            throw new NotImplementedException();
        }
        public Task<IEnumerable<CardItemDto>> GetCart(int customerId)
        {
            throw new NotImplementedException();
        }
        public Task Checkout(int customerId)
        {
            throw new NotImplementedException();
        }










        public async Task AddProduct(ProductDto productdto)
        {

            var product = new Product
            {
                 ProductName= productdto.ProductName,
                 ProductShortName=productdto.ProductShortName,
                 ProductPrice=productdto.ProductPrice,
                 ProductDescription=productdto.ProductDescription,
                 DelevaryTimeSpan=productdto.DelevaryTimeSpan,
                 CreateTime=DateTime.UtcNow,
                 ImageFile=productdto.ImageFile,
                 CategoryId= productdto.CategoryId
             



            };
           await _context.Products.AddAsync(product);
           await _context.SaveChangesAsync();

            


        }

      

        public async Task Delete(int id)
        {
            var data = await _context.Products.FindAsync(id);

            if (data == null)
            {
                throw new NotImplementedException("item not found");
            }
            _context.Products.Remove(data);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();

            

            
        }

        public  IQueryable<Product> GetAllAsync(int pageNumber, int pageSize)
        {
            return _context.Products.AsQueryable();
        }

        public async Task< Product?> GetById(int id)
        {
           return  await _context.Products.FindAsync(id);

           // if (product == null) return null;

            //var dto = new ProductDto
            //{
            //    ProductName=product.ProductName,
            //    ProductShortName=product.ProductShortName,
            //    ProductDescription=product.ProductDescription,
            //    ProductPrice=product.ProductPrice,
            //    DelevaryTimeSpan=product.DelevaryTimeSpan,
            //    ImageFile=product.ImageFile,
            //    Category_ID=product.Category_ID
                

            //};
            

        }

       

        public async Task<IEnumerable< ProductDto>> GetcategoryProductById(int CategoryId)
        {
            var product = await _context.Products.Where(p => p.CategoryId == CategoryId)
                .Select(p => new ProductDto
            {
                ProductName = p.ProductName,
                ProductShortName = p.ProductShortName,
                ProductDescription = p.ProductDescription,
                ProductPrice = p.ProductPrice,
                DelevaryTimeSpan = p.DelevaryTimeSpan,
                ImageFile = p.ImageFile,


            }).ToListAsync();
            return product;
            
            
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, ProductDto productdto)
        {
            var productItem = await _context.Products.FindAsync(id);

            if (productItem == null)
            {
                throw new Exception("Product not foundt");
            }
            productItem.ProductName = productdto.ProductName;
            productItem.ProductShortName = productdto.ProductShortName;
            productItem.ProductPrice = productdto.ProductPrice;
            productItem.ProductDescription = productdto.ProductDescription;
            productItem.ImageFile = productdto.ImageFile;
            productItem.CategoryId = productdto.CategoryId;
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<CardItemDto>> GetCartItem(int customerId, int productId)
        {
            throw new NotImplementedException();
        }

        public void Update(CardItemDto cartItem)
        {
            throw new NotImplementedException();
        }
    }
}
