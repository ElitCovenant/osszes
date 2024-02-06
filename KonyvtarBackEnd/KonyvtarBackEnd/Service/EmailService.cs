using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Service.IEmailServices;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
namespace KonyvtarBackEnd.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;
        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(configuration.GetSection("EmailSettings:EmailUserName").Value));

            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(configuration.GetSection("EmailSettings:EmailHost").Value, 587, SecureSocketOptions.StartTls);

            smtp.Authenticate(configuration.GetSection("EmailSettings:EmailUserName").Value, configuration.GetSection("EmailSettings:EmailPassword").Value);

            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
