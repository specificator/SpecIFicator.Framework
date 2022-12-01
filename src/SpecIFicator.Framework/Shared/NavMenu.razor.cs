using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.Configuration;
using SpecIFicator.Framework.Configuration.DataModels;

namespace SpecIFicator.Framework.Shared
{
    public partial class NavMenu
    {
        [Inject]
        public IStringLocalizerFactory LocalizerFactory { get; set; }


        protected override void OnInitialized()
        {
            
        }
    }
}
