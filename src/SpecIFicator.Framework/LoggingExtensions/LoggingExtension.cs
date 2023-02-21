using Microsoft.JSInterop;

namespace SpecIFicator.Framework.LoggingExtensions
{
    public static class LoggingExtension
    {
        public static async void LogToWebConsoleAsync(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("console.log", message);
        }
    }
}
