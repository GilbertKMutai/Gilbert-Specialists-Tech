using Microsoft.JSInterop;
using Syncfusion.Blazor.Navigations;

namespace MagnusApp.Client.Pages.Shared;

public class DisplayTestimonialBase : ComponentBase
{

    protected SfCarousel carouselRef;
    protected bool carouselAutoPlay = true;
    private DotNetObjectReference<DisplayTestimonialBase> objRef;

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    protected override void OnInitialized()
    {
        objRef = DotNetObjectReference.Create(this);
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync("startResizeListener", objRef);

        }
    }

    [JSInvokable]
    public void DisableAutoPlay(int windowWidth)
    {
        // Disable autoplay for screen sizes greater than or equal to 1000px
        carouselAutoPlay = windowWidth < 1000;
        StateHasChanged();
    }

}