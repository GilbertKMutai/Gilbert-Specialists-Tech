using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnusApp.Shared.Configuration
{
    public interface IMailSettings
    {
        public string EmailHost { get; }
        public string EmailUserName { get; }
        public string EmailPassword { get; }

    }
}
