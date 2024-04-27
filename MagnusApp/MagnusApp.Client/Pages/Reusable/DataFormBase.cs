using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Syncfusion.Blazor.DataForm;

namespace MagnusApp.Client.Pages.Reusable
{
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
}
