using MagnusApp.Shared;
using Microsoft.AspNetCore.Components;


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

        void refresh()
        {

            ClientModel = new EmailDto();

        }
    }

}
