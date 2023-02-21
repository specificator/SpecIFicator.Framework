using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SpecIFicator.Framework.LoggingExtensions;
using SpecIFicator.Framework.PluginManagement;

namespace SpecIFicator.Framework.RazorComponents
{
    public partial class AddPluginStyles
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        private List<string> StylesheetNames { get; set; }

        protected override void OnInitialized()
        {
            StylesheetNames = PluginManager.GetStylesheetNames();

            if(StylesheetNames != null )
            {
                JSRuntime.LogToWebConsoleAsync("StylesheetNames count = " + StylesheetNames.Count);
                foreach(string stylesheetName in StylesheetNames)
                {
                    JSRuntime.LogToWebConsoleAsync($"{stylesheetName}");
                }

            }
            else
            {
                JSRuntime.LogToWebConsoleAsync("StylesheetNames is null!");
            }
            
        }
    }
}