using MagnusApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor.DataForm;
using Syncfusion.Blazor.Inputs;


namespace MagnusApp.Client.Pages;

public class ContactBase : ComponentBase
{
    public SfDataForm dataForm;

    protected EmailDto ClientModel = new EmailDto();
    [Inject]
    public IEmailService EmailService { get; set; }
    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected async void HandleSubmit ()
    {
        await EmailService.SendEmail(ClientModel);
        ClearForm();
    }


    protected void ClearForm()
    {
        ClientModel.Subject = "";
        ClientModel.Body = "";
        ClientModel.From = "";
    }

    protected void HandleValidSubmit ()
    {
       

    }

}
