namespace MagnusApp.Client.Pages;

public class ContactBase : ComponentBase
{
    
    //public SfDataForm editFormRespon = new SfDataForm();

    protected EmailDto ClientModel = new EmailDto();
    [Inject]
    public IEmailService EmailService { get; set; }
    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    //protected async void HandleValidSubmit()
    //{
    //   await EmailService.SendEmail(ClientModel);
    //    ClientModel = new EmailDto();
    //    dataForm.Refresh();
    //}

    public async Task HandleValidSubmit()
    {
        //ClientModel = new EmailDto();
    }

    //ClientModel.Subject = string.Empty;
    //ClientModel.Body = string.Empty;
    //ClientModel.From = string.Empty;

}
