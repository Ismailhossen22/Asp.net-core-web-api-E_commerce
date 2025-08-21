namespace Bigbasket_Ecommerce.Models.Dto
{
    public class ResetPasswordDto
    {

        public string Email { get; set; }
        public string OtpCode { get; set; }

        public string NewPassword { get; set; }


    }
}
