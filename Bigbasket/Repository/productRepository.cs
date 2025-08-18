using Bigbasket_Ecommerce.Data;
using Bigbasket_Ecommerce.Models;
using Bigbasket_Ecommerce.Models.Dto;
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

        public async Task AddProduct(ProductDto productdto)
        {

            var product = new Products
            {
                 ProductName= productdto.ProductName,
                 ProductShortName=productdto.ProductShortName,
                 ProductPrice=productdto.ProductPrice,
                 ProductDescription=productdto.ProductDescription,
                 DelevaryTimeSpan=productdto.DelevaryTimeSpan,
                 CreateTime=DateTime.UtcNow,
                 ImageFile=productdto.ImageFile,
                 Category_ID= productdto.Category_ID
             



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

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();

            

            
        }
       

        public async Task< Products?> GetById(int id)
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

        public async Task<IEnumerable< ProductDto>> GetcategoryProductById(int Categoryid)
        {
            var product = await _context.Products.Where(p => p.Category_ID == Categoryid).Select(p => new ProductDto
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

        public async Task Update(ProductDto productdto,int id )
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
            productItem.Category_ID = productdto.Category_ID;
            await _context.SaveChangesAsync();
        }









    }
}
