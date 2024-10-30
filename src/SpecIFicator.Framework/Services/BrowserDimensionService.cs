using Microsoft.JSInterop;
using SpecIFicator.Framework.Services.DataModels;

namespace SpecIFicator.Framework.Services
{
    public class BrowserDimensionService
    {
        private readonly IJSRuntime _jsRuntime;

        public BrowserDimensionService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<BrowserDimension> GetBrowserDimension()
        {
            return await _jsRuntime.InvokeAsync<BrowserDimension>("getDimensions");
        }
    }
}
