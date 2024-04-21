using MagnusApp.Shared;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DataForm;
using Syncfusion.Blazor.Inputs;


namespace MagnusApp.Client.Pages;

public class ContactBase : ComponentBase
{

    protected EmailDto ClientModel = new EmailDto();

    [Inject]
    public IEmailService EmailService { get; set; }
    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected void HandleValidSubmit ()
    {
        EmailService.SendEmail(ClientModel);

        //ClientModel.Subject = string.Empty;
        //ClientModel.From = string.Empty;
        //ClientModel.Body = string.Empty;
    }

    protected void HandleSubmit()
    {
        //
    }
}
