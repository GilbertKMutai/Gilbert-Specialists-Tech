using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Buttons;
namespace MagnusApp.Client.Pages;

public class HiremeBase : ComponentBase
{
    protected EmailDto ClientModel = new EmailDto();

    protected string Xvalue = "center";
    protected string Yvalue = "center";
    protected bool IsVisible { get; set; } = false;
    protected string Checked { get; set; } = "center center";
    protected int ViewportWidth { get; set; }
    protected int ViewportHeight { get; set; }

    
    protected void OpenDialog()
    {
        this.IsVisible = true;
    }

    protected void CloseDialog()
    {
        this.IsVisible = false;
    }




    //public void OnChangeHandler(ChangeArgs<string> arg)
    //{
    //    this.Xvalue = arg.Value.ToString().Split(' ')[0];
    //    this.Yvalue = arg.Value.ToString().Split(' ')[1];
    //    this.StateHasChanged();
    //}
}
