namespace Bigbasket_Ecommerce.Models.Dto
{
    public class RegisterUserDto
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string password { get; set; }
    }
}
