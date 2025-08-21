
using MailKit.Net.Smtp;
using MimeKit;

namespace Bigbasket_Ecommerce.Repository
{
    public class EmailService : IEmailService
    {

        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string ToEmail, string Subject, string body)
        {


            var email = new MimeMessage();


            email.From.Add(new MailboxAddress("Asp.net Identity", _config["EmailSetting:FromEmail"]));

            email.To.Add(new MailboxAddress("", ToEmail));

            email.Subject = Subject;
            email.Body = new TextPart("html") { Text = body };


            using var smpt = new SmtpClient();
            
            await smpt.ConnectAsync("smtp.gmail.com", 587, false);
            await smpt.AuthenticateAsync(_config["EmailSetting:FromEmail"], _config["EmailSetting:AppPassword"]);

            await smpt.SendAsync(email);
            await smpt.DisconnectAsync(true);





            
        }
    }
}
