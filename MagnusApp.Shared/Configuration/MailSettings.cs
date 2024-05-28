using Microsoft.Extensions.Configuration;
namespace MagnusApp.Shared.Configuration;

public class MailSettings : IMailSettings
{
    private readonly IConfiguration configuration;

    public MailSettings(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    //public string EmailHost => configuration["EmailHost"]!;
    //public string EmailUserName => configuration["EmailUserName"]!;
    //public string EmailPassword => configuration["EmailPassword"]!;

    public string EmailHost => configuration["MailSettings:EmailHost"]!;
    public string EmailUserName => configuration["MailSettings:EmailUserName"]!;
    public string EmailPassword => configuration["MailSettings:EmailPassword"]!;
}
