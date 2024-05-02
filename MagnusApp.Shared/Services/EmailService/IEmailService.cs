using MagnusApp.Shared.Models;
namespace MagnusApp.Shared.Services.EmailService;

public interface IEmailService
{
    Task SendEmail(EmailDto request);
}
