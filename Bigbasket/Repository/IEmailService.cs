namespace Bigbasket_Ecommerce.Repository
{
    public interface IEmailService
    {

        Task SendEmailAsync(String ToEmail, string Subject, string body);

    }
}
