using System.Threading.Tasks;

namespace Watermark.Services
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}