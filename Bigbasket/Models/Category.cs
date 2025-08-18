using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bigbasket_Ecommerce.Models
{
    public class Category
    {
        
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [NotMapped]
        public ICollection<Products>? productList { get; set; }
      
       


    }
}
