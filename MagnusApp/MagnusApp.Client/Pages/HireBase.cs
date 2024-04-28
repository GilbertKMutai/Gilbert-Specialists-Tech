using Microsoft.AspNetCore.Components;

namespace MagnusApp.Client.Pages;

public class HireBase : ComponentBase
{
    protected EmailDto ClientModel = new EmailDto();
    protected bool IsVisible { get; set; } = true;

    protected void OpenDialog()
    {
        this.IsVisible = true;
    }

    protected void CloseDialog()
    {
        this.IsVisible = false;
    }
}
