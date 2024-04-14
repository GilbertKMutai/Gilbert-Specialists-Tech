using MagnusApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MagnusApp.Client.Pages
{
    public class ContactBase : ComponentBase
    {
        public int Height { get; set; }
        public int Width { get; set; }

        //public string Css { get; set; } = "322px";

        [Inject]
        public IJSRuntime JsRuntime { get; set; }


        protected ClientInfo ClientModel = new ClientInfo();

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var dimension = await JsRuntime.InvokeAsync<WindowDimension>("getWindowDimensions");
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
