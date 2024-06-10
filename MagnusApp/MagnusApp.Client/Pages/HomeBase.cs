namespace MagnusApp.Client.Pages;

public class HomeBase:ComponentBase
{
    protected string? CssClass { get; set; } = "spin-container";
    protected bool IsVisible { get; set; } = true;

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(3500);
        IsVisible = false;
        CssClass = null;
    }

}
