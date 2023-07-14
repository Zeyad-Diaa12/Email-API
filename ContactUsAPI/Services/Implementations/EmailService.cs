using ContactUsAPI.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace ContactUsAPI.Services.Implementations
{
    public class EmailService : IEmailService
    {
        public EmailResponse SendEmail(string body)
        {
            var mail = new MimeMessage();
            
            mail.From.Add(MailboxAddress.Parse("Your Email"));
            
            mail.To.Add(MailboxAddress.Parse("Your Email"));
            
            mail.Subject = "Subject";
            
            mail.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            
            //You Can Change The Service You Send Through e.g: smtp-mail.outlook.com
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

            //If Using Gmail as the SMTP Server You Add Your Email and then go to App Passwords and Generate A password to use 
            smtp.Authenticate("Your Email", "Your Password");

            smtp.Send(mail);
            
            smtp.Disconnect(true);

            return new EmailResponse
            {
                IsSuccess = true
            };
        }
    }
}
