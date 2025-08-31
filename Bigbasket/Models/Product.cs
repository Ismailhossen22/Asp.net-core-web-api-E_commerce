using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Bigbasket_Ecommerce.Models
{
    public class Product
    {
        [Key]
       public int ProductId { get; set; }
    
        public string ProductName { get; set; }
     
     
        public string? ProductShortName { get; set; }
    
        public double ProductPrice { get; set; }
        public int Stock { get; set; }

        public string? DelevaryTimeSpan { get; set; }

    
        public string? ImageFile { get; set; }
       
       
        public string? ProductDescription { get; set; }
     

        public DateTime CreateTime { get; set; } 
      
        
  
        public int CategoryId { get; set; }


        public Category Category { get; set; } = null!;

        public CartItem? CartItem { get; set; }
       


    }
}
