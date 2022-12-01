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
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.Configuration;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.ViewModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.DataModels.Manipulation;
using SpecIFicator.Framework.CascadingValues;

namespace SpecIFicator.Framework.Pages
{
    public partial class PluginPage
    {
        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        private string _topic;

        private HierarchyEditorContext _dataContext = new HierarchyEditorContext();

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


                    //StateHasChanged();
                }
            }
        }

        [Parameter]
        public string KeyString { get; set; }

        private Type PageType { get; set; }

        protected override void OnInitialized()
        {
            
        }
    }
}