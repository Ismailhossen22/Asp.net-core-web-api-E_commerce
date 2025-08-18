namespace Bigbasket_Ecommerce.Models
{
    public class ApiResponse<T>
    {

        public string message { get; set; }

        public bool status { get; set; }
        public T Data { get; set; }



    }
}
