using Syncfusion.Blazor.DataForm;
using Syncfusion.Blazor.Notifications;
namespace MagnusApp.Client.Pages.Reusables;

public class DataFormBase : ComponentBase
{
    protected SfToast ToastObj = new SfToast();
    protected string PositionX = "Right";
  

    protected string ToastContent = "<b>Success!</b> We are doing our best to reach out to you within 12 hrs, if not sooner. We appreciate your patience and apologize in advance if it takes a little longer.";

    [CascadingParameter]
    public EmailDto ClientModel { get; set; }

    public SfDataForm dataForm { get; set; }

    [Inject]
    public IEmailService EmailService { get; set; }

    [Parameter]
    public EventCallback<EmailDto> OnFormSubmited { get; set; }

    protected async void HandleSubmit()
    {
        await this.ToastObj.ShowAsync();
        await EmailService.SendEmail(ClientModel);
        ClientModel = new EmailDto();
        dataForm.Refresh();
        await Task.Delay(2200);
        await OnFormSubmited.InvokeAsync(ClientModel);
    }
}
