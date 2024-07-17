using Microsoft.JSInterop;

namespace MagnusApp.Client.Pages.Reusables;

public class DisplayProjectBase : ComponentBase
{
    private bool firstRender = true;    

    [Inject]
    NavigationManager NavigationManager { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //    if (firstRender)
    //    {

    //        await JSRuntime.InvokeAsync<string>("addEventListener");
    //    }
    //}

    protected void OpenWebsite(string uri)
    {
        NavigationManager.NavigateTo(uri, false);
    }


}
