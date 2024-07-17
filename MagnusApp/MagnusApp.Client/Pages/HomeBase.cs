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

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    protected override async Task OnInitializedAsync()
    {
        //await JSRuntime.InvokeAsync<string>("onscroll");
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender) {

            //await JSRuntime.InvokeAsync<string>("addEventListener");
            await JSRuntime.InvokeAsync<string>("onscroll");
        }
    }


    //try tests
    protected MarkupString text;

    protected uint[] quoteArray =
        new uint[]
        {
            60, 101, 109, 62, 67, 97, 110, 39, 116, 32, 115, 116, 111, 112, 32,
            116, 104, 101, 32, 115, 105, 103, 110, 97, 108, 44, 32, 77, 97,
            108, 46, 60, 47, 101, 109, 62, 32, 45, 32, 77, 114, 46, 32, 85, 110,
            105, 118, 101, 114, 115, 101, 10, 10,
        };

    protected async Task ConvertArray()
    {
        text = new(await JSRuntime.InvokeAsync<string>("convertArray", quoteArray));
    }

}
