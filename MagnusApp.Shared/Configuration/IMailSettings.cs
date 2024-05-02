namespace MagnusApp.Shared.Configuration;

public interface IMailSettings
{
    public string EmailHost { get; }
    public string EmailUserName { get; }
    public string EmailPassword { get; }

}
