using MagnusApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnusApp.Repositories.EmailRepository
{
    public interface IEmailRepository
    {
        void SendEmail(EmailDto request);
    }
}
