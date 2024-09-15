using Microsoft.JSInterop;
using Syncfusion.Blazor.Navigations;

namespace MagnusApp.Client.Pages.Reusables
{
    public class DisplayTestimonialBase : ComponentBase
    {

        protected SfCarousel carouselRef;
        protected static bool carouselAutoPlay = true;

        [Inject]
        public IJSRuntime JSRuntime { get; set; }



        [JSInvokable]
        private static void DisableAutoPlay()
        {
            // Disable autoplay for screen sizes greater than or equal to 1000px
            carouselAutoPlay = false;

            //InvokeAsync(StateHasChanged);
        }

    }
}
