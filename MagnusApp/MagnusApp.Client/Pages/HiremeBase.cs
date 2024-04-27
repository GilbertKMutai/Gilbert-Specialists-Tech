using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MagnusApp.Client.Pages.Reusable;
namespace MagnusApp.Client.Pages;

public class HiremeBase : ComponentBase
{

    PopupCard card;

    public void DisplayCard(MouseEventArgs args)
    {
        card.Show(args);
    }

}
