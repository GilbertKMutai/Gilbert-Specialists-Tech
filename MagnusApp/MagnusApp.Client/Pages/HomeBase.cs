using Microsoft.JSInterop;

namespace MagnusApp.Client.Pages;

public class HomeBase:ComponentBase
{
    public bool firstRender = true;
    //protected string? Cssclass { get; set; } = "spinner-container";
    //protected bool IsVisible { get; set; } = true;

    //protected override async Task OnInitializedAsync()
    //{
    //    await Task.Delay(3500);
    //    IsVisible = false;
    //    Cssclass = null;
    //}

    //[Inject]
    //public IJSRuntime JSRuntime { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {

            //await JSRuntime.InvokeAsync<string>("addEventListener");
            //await JSRuntime.InvokeAsync<string>("onscroll");
            //StateHasChanged();
        }
    }

}
