using MagnusApp.Shared.Models;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MagnusApp.Shared.Configuration;

namespace MagnusApp.Repositories.EmailRepository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IMailSettings mailSettings;

        public EmailRepository(IMailSettings mailSettings)
        {
            this.mailSettings = mailSettings;
        }

        public void SendEmail(EmailDto request)
        {
            string text = $"{request.Body} <br> <br>" + $"FROM: l{request.From}";
            //text = text.Replace("#", Environment.NewLine);

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(request.From));
            email.To.Add(MailboxAddress.Parse("mutaigilly02@gmail.com"));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = text };

            using var smtp = new SmtpClient();
            smtp.Connect(mailSettings.EmailHost, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.EmailUserName, mailSettings.EmailPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}