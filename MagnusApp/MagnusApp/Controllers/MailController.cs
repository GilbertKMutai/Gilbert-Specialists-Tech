
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MagnusApp.Shared.Services.EmailService;
using MagnusApp.Shared.Models;

namespace MagnusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public MailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        [Route("SendMail")]
        public IActionResult SendMail(EmailDto request)
        {
            emailService.SendEmail(request);

            return Ok();
        }
    }
}
