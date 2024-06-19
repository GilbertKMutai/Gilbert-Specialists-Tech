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

   

    public async Task HandleValidSubmit()
    {
        //ClientModel = new EmailDto();
    }



}
