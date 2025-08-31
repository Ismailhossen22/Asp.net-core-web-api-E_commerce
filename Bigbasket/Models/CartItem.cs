using System.ComponentModel.DataAnnotations;

namespace Bigbasket_Ecommerce.Models
{
    public class CartItem
    {

        [Key]
        public int CardItemId { get; set; }
        
        public int ProductId { get; set; }
        public Product? Products { get; set; } = null!;
       public int UserId { get; set; }
       public User? User { get; set; } = null!;

        public int Quantity { get; set; }
        public double Price { get; set; }




    }
}
