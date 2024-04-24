using Microsoft.AspNetCore.Components;

namespace MagnusApp.Client.Pages.Reusable
{
    public class DataFormBase : ComponentBase
    {
        [CascadingParameter]
        public EmailDto ClientModel { get; set; }
    }
}
