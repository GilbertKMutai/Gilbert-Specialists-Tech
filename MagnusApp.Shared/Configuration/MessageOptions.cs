using MagnusApp.Shared.Configuration;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
namespace MagnusApp.Shared.Configuration;

public class MessageOptions : IMessageOptions
{
    private readonly IConfiguration configuration;

    public MessageOptions()
    {
    }

    public MessageOptions(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public string EmailHost => configuration["MailSettings:EmailHost"]!;
    //public string EmailAuthKey => configuration.GetSection("MailChimpAuthKey").ToString();
}
