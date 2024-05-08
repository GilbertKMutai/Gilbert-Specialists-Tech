using MagnusApp.Shared.Models;
using MagnusApp.Shared.Services.EmailService;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DataForm;
namespace MagnusApp.Components.Test;

public class DataFormBase : ComponentBase
{
    public EmailDto ClientModel = new EmailDto();

    public SfDataForm dataForm { get; set; }

    [Inject]
    public IEmailService EmailService { get; set; }

    protected bool RememberMe { get; set; } = false;

    protected async void HandleValidSubmit()
    {
        await EmailService.SendEmail(ClientModel);
        ClientModel = new EmailDto();
        dataForm.Refresh();
    }
}
