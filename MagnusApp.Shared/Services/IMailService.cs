using MagnusApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnusApp.Shared.Services;

public interface IMailService
{
    bool SendMail(MailData mailData);
}
