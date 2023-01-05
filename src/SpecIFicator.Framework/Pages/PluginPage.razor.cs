using Microsoft.AspNetCore.Components;
using SpecIFicator.Framework.Configuration;
using MDD4All.SpecIF.DataProvider.Contracts;

namespace SpecIFicator.Framework.Pages
{
    public partial class PluginPage
    {
        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        private string _topic;

        [Parameter]
        public string Topic { 
            
            get
            {
                return _topic;
            }

            set
            {
                _topic = value;
                if (_topic != null)
                {
                    PageType = DynamicConfigurationManager.GetComponentTypeByID(Topic);
                }
            }
        }

        [Parameter]
        public string KeyString { get; set; }

        private Type PageType { get; set; }
    }
}