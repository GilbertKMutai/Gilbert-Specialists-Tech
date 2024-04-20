using MagnusApp.Shared;
using Microsoft.AspNetCore.Components;


namespace MagnusApp.Client.Pages;

public class ContactBase : ComponentBase
{ 
    protected ClientInfo ClientModel = new ClientInfo();

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

}
