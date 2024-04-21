using MagnusApp.Shared.Models;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MagnusApp.Shared.Configuration;
using System.Net.Http.Json;

namespace MagnusApp.Shared.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient httpClient;

        public EmailService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task SendEmail(EmailDto request)
        {
            await httpClient.PostAsJsonAsync<EmailDto>("api/mail/sendmail", request);
        }
    }
}