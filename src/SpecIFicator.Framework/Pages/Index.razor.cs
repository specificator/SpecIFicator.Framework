using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using SpecIFicator.Framework;
using SpecIFicator.Framework.Shared;
using SpecIFicator.Framework.RazorComponents;
using MDD4All.SpecIF.DataProvider.Contracts;
using SpecIFicator.Framework.CascadingValues;
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.Configuration;
using SpecIFicator.Framework.Configuration.DataModels;

namespace SpecIFicator.Framework.Pages
{
    public partial class Index
    {
        [Inject]
        private ISpecIfDataProviderFactory _specIfDataProviderFactory { get; set; }

        [Inject]
        private IStringLocalizer<Index> L { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        private SpecIfDataConnectorContext _dataContext = new SpecIfDataConnectorContext();

        private string DefaultPage { get; set; } = "";

        protected override void OnInitialized()
        {
            _dataContext.SpecIfDataProviderFactory = _specIfDataProviderFactory;
            _dataContext.ConnectAction = HandleConnectClick;

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