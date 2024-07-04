namespace MagnusApp.Client.Pages;

public class ContactBase : ComponentBase
{
    

    protected EmailDto ClientModel = new EmailDto();

    [Inject]
    public IEmailService EmailService { get; set; }

    public async Task HandleSubmit()
    {
        //ClientModel = new EmailDto();
    }



}
