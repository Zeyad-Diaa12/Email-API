using ContactUsAPI.Models;

namespace ContactUsAPI.Services
{
    public interface IEmailService
    {
        EmailResponse SendEmail(string body);
    }
}
