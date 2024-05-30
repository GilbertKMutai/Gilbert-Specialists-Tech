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

        //[Inject]
        //public IConfiguration configuration1 { get; set; }
        //public string EmailAuthKey => configuration1["MailChimpAuthKey"]!;
        public string EmailAuthKey { get; set; } = "974a1041e36f7a0d807fbc5d788c741c-us17";
    }
}
