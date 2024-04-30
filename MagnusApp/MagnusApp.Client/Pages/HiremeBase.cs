using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
namespace MagnusApp.Client.Pages;

public class HiremeBase : ComponentBase
{
    protected EmailDto ClientModel = new EmailDto();
    protected bool IsVisible { get; set; } = false;

    protected void OpenDialog()
    {
        this.IsVisible = true;
    }

    protected void CloseDialog()
    {
        this.IsVisible = false;
    }
}
