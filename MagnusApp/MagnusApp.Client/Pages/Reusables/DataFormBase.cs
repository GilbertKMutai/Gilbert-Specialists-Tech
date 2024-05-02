using Syncfusion.Blazor.DataForm;
namespace MagnusApp.Client.Pages.Reusables;

public class DataFormBase : ComponentBase
{
    [CascadingParameter]
    public EmailDto ClientModel { get; set; }

    public SfDataForm dataForm { get; set; }

    [Inject]
    public IEmailService EmailService { get; set; }

    [Parameter]
    public EventCallback<EmailDto> OnFormSubmited { get; set; }

    protected async void HandleValidSubmit()
    {
        await EmailService.SendEmail(ClientModel);
        await OnFormSubmited.InvokeAsync(ClientModel);
        ClientModel = new EmailDto();
        dataForm.Refresh();
    }
}
