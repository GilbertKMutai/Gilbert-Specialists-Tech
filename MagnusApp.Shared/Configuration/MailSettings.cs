using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnusApp.Shared.Configuration
{
    public class MailSettings : IMailSettings
    {
        private readonly IConfiguration configuration;

        public MailSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string EmailHost => configuration["MailSettings:EmailHost"];  
        public string EmailUserName  => configuration["MailSettings:EmailUserName"]; 
        public string EmailPassword => configuration["MailSettings:EmailPassword"];  
    }
}
