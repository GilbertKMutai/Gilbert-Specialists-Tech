using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnusApp.Shared.Configuration
{
    public class AuthMessageSenderOptions
    {
        private readonly IConfiguration configuration;

        public AuthMessageSenderOptions()
        {
        }

        public AuthMessageSenderOptions(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string EmailAuthKey => configuration["MailChimpAuthKey"];

    }
}
