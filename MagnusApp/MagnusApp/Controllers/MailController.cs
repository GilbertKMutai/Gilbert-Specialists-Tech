
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MagnusApp.Shared.Services.EmailService;
using MagnusApp.Shared.Models;
using MagnusApp.Shared.Configuration;

namespace MagnusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        //private readonly IConfiguration configuration;
        private readonly IEmailService emailService;

        public MailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        [Route("SendMail")]
        public IActionResult SendMail(EmailDto request)
        {
            //var mailHost = configuration.GetValue<string>("MailSettings:EmailHost");
            //var mailUserName = configuration.GetValue<string>("MailSettings:EmailUserName");
            //var mailPassword = configuration.GetValue<string>("MailSettings:EmailPassword");



            emailService.SendEmail(request);

            return Ok();
        }
    }
}
