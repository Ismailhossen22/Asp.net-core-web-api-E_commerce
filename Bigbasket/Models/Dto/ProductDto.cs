using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bigbasket_Ecommerce.Models.Dto
{
    public class ProductDto
    {

      
        public int ProductId { get; set; }
      
       
        public string ProductName { get; set; }
       

        public string ProductShortName { get; set; }
      
        public double ProductPrice { get; set; }
      

        public string DelevaryTimeSpan { get; set; }

       
        public string? ImageFile { get; set; }


        public string ProductDescription { get; set; }


       // public DateTime CreateTime { get; set; } 

       
        public int Category_ID { get; set; }

       















    }
}
