using MagnusApp.Shared.Models;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MagnusApp.Shared.Configuration;

namespace MagnusApp.Shared.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings mailSettings;

        public EmailService(IOptions<MailSettings> mailSettingsOptions)
        {
            this.mailSettings = mailSettingsOptions.Value;
        }

        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(ApplicationConfiguration.GetSetting("EmailHost")));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(mailSettings.EmailHost, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.EmailUserName, mailSettings.EmailPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
