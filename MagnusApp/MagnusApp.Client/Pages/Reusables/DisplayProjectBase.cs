using Microsoft.JSInterop;

namespace MagnusApp.Client.Pages.Reusables;

public class DisplayProjectBase : ComponentBase
{
    private bool firstRender = true;
    public string Css { get; set; } = string.Empty;

    [Inject]
    NavigationManager NavigationManager { get; set; }



    protected void OpenWebsite(string uri)
    {
        NavigationManager.NavigateTo(uri, false);
    }
}
