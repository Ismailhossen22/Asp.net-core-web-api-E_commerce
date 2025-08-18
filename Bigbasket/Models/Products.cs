using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Bigbasket_Ecommerce.Models
{
    public class Products
    {
        [Required]
       public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        [Required]
     
        public string ProductShortName { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]

        public string DelevaryTimeSpan { get; set; }

        [Required]
        public string? ImageFile { get; set; }
       
       
        public string ProductDescription { get; set; }
        [Required]

        public DateTime CreateTime { get; set; } 
      

        [ForeignKey("Category")]
        [Required]
        public int Category_ID { get; set; }

        [NotMapped]
        public Category? category { get; set; }
       


    }
}
