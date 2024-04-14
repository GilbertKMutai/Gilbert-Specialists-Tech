using MagnusApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MagnusApp.Components.Pages
{
    public class ContactBase : ComponentBase
    {

        public int Height { get; set; }
        public int Width { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }
       

        protected ClientInfo ClientModel = new ClientInfo();

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        public async Task OnButtonClick()
        {
            var dimension = await JsRuntime.InvokeAsync<WindowDimension>
                ("getWindowDimensions");
            Height = dimension.Height;
            Width = dimension.Width;
        }

        public class WindowDimension 
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }


    }
}
