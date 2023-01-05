using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.DataProvider.Contracts;
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.Configuration;
using SpecIFicator.Framework.Configuration.DataModels;
using MDD4All.SpecIF.ViewModels;

namespace SpecIFicator.Framework.Pages
{
    public partial class Index
    {
        [Inject]
        private ISpecIfDataProviderFactory SpecIfDataProviderFactory { get; set; }

        [Inject]
        private IStringLocalizer<Index> L { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private DataConnectorViewModel DataContext { get; set; } = new DataConnectorViewModel();

        private string DefaultPage { get; set; } = "";

        protected override void OnInitialized()
        {
            DataContext.SpecIfDataProviderFactory = SpecIfDataProviderFactory;
            DataContext.ConnectAction = HandleConnectClick;

            List<ComponentDefinition> mainComponents = DynamicConfigurationManager.GetMainComponents();

            if(mainComponents.Any())
            {
                DefaultPage = "/pluginPage/" + mainComponents[0].ID;
            }
        }

        private void HandleConnectClick()
        {
            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }
    }
}