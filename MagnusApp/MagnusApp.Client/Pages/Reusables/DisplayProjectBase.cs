namespace MagnusApp.Client.Pages.Reusables;

public class DisplayProjectBase : ComponentBase
{

    [Inject]
    NavigationManager NavigationManager { get; set; }

    protected void OpenWebsite(string uri)
    {
        NavigationManager.NavigateTo(uri, false);
    }   

}
