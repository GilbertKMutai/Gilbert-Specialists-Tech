
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MagnusApp.Shared.Models;
using MagnusApp.Shared.Configuration;
using MagnusApp.Repositories.EmailRepository;

namespace MagnusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailRepository emailRepository;

        //private readonly IConfiguration configuration;
        public MailController(IEmailRepository emailRepository)
        {
            this.emailRepository = emailRepository;
        }

        [HttpPost]
        [Route("SendMail")]
        public IActionResult SendMail(EmailDto request)
        {
            //var mailHost = configuration.GetValue<string>("MailSettings:EmailHost");
            //var mailUserName = configuration.GetValue<string>("MailSettings:EmailUserName");
            //var mailPassword = configuration.GetValue<string>("MailSettings:EmailPassword");



            emailRepository.SendEmail(request);

            return Ok();
        }
    }
}
