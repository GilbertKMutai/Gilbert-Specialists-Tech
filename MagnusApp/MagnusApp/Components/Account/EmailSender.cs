using MagnusApp.Data;
using MagnusApp.Shared.Configuration;
using MailKit.Net.Smtp;
using Mandrill;
using Mandrill.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace MagnusApp.Components.Account
{

    //Custom Email confirmation configuration of identity using MailChimp as the provider
    public class EmailSender(IMessageOptions messageOptions, ILogger<EmailSender> logger, IMailSettings mailSettings) : IEmailSender<ApplicationUser>

    {
        private readonly IMessageOptions messageOptions = messageOptions;
        private readonly ILogger logger = logger;
        private readonly IMailSettings mailSettings = mailSettings;

        public Task SendConfirmationLinkAsync(ApplicationUser user, string email,
            string confirmationLink) => SendEmailAsync(email, "Confirm your email", $"Please confirm your account by " + $"<a href='{confirmationLink}'>clicking here</a>.");

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email,
            string resetCode) => SendEmailAsync(email, "Reset your password", $"Resest your password using the following code: <br /> {resetCode}");

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email,
            string resetLink) => SendEmailAsync(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>");

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(messageOptions.EmailAuthKey))
            {
                throw new Exception("Null EmailAuthKey");
            }

            await Execute(messageOptions.EmailAuthKey, subject, message, toEmail);
        }

        public async Task Execute (string apiKey, string subject, string message, string toEmail)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("mutaigilly02@gmail.com"));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) {Text = message };

            using var smtp = new SmtpClient();
            smtp.Connect(mailSettings.EmailHost, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.EmailUserName, mailSettings.EmailPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        //Sending email using Mandrill requires google workspace account yet I only have personal account at the moment
        //public async Task Execute (string apiKey, string subject, string message, string toEmail)
        //{
        //    var api = new MandrillApi(apiKey);
        //    var mandrillMessage = new MandrillMessage("mutaigilly02@gmail.com", toEmail, subject, message);
        //    await api.Messages.SendAsync(mandrillMessage);

        //    logger.LogInformation("Email to {EmailAddress} sent!", toEmail);
        //}
    }
}
