namespace MagnusApp.Client.Pages.Reusables;

public class DisplayProjectBase : ComponentBase
{

    [Inject]
    NavigationManager NavigationManager { get; set; }
    public void OnBtnClick()
    {

    }

    protected void OpenOnlineShoppingCart()
    {
        NavigationManager.NavigateTo("/", false);
    }   
    protected void OpenSalesManagementApp()
    {
        NavigationManager.NavigateTo("/", false);
    }    
    
    protected void OpenLoomon()
    {
        NavigationManager.NavigateTo("/", false);
    }   
    
    protected void OpenBeFit()
    {
        NavigationManager.NavigateTo("/", false);
    }    
    
}
