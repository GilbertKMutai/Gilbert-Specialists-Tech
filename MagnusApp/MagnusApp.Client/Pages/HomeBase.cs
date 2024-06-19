namespace MagnusApp.Client.Pages;

public class HomeBase:ComponentBase
{
    protected string? Cssclass { get; set; } = "spinner-container";
    protected bool IsVisible { get; set; } = true;

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(3500);
        IsVisible = false;
        Cssclass = null;
    }

}
