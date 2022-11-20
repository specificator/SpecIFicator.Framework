using SpecIFicator.Framework.PluginManagement;

namespace SpecIFicator.Framework.RazorComponents
{
    public partial class AddPluginStyles
    {
        private List<string> StylesheetNames { get; set; }

        protected override void OnInitialized()
        {
            StylesheetNames = PluginManager.GetStylesheetNames();


        }
    }
}