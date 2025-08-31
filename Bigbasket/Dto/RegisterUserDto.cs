namespace Bigbasket_Ecommerce.Dto
{
    public class RegisterUserDto
    {

        

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string password { get; set; }
        public string? Role { get; set; }

    }
}
