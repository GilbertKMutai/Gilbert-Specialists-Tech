using Microsoft.JSInterop;

namespace MagnusApp.Client.Pages.Reusables;

public class DisplayProjectBase : ComponentBase
{

    [Inject]
    NavigationManager NavigationManager { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    protected void OpenWebsite(string uri)
    {
        NavigationManager.NavigateTo(uri, false);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JSRuntime.InvokeAsync<string>("onscroll");
    }

}
