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
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.CascadingValues;
using MDD4All.SpecIF.ViewModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataModels.Manipulation;
using SpecIFicator.Framework.Configuration;

namespace SpecIFicator.Framework.Pages
{
    public partial class HierarchyEditorPage
    {
        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        [Parameter]
        public string KeyString { get; set; }

        private HierarchyEditorContext _dataContext = new HierarchyEditorContext();

        private Type _hierarchyEditorType;

        protected override void OnInitialized()
        {
            if(KeyString != null)
            {
                Key key = new Key();
                key.InitailizeFromKeyString(KeyString);
                HierarchyViewModel hierarchyViewModel = new HierarchyViewModel(DataProviderFactory.MetadataReader,
                                                                               DataProviderFactory.DataReader,
                                                                               DataProviderFactory.DataWriter,
                                                                               key);

                _dataContext.HierarchyViewModel = hierarchyViewModel;

                Type type = DynamicConfigurationManager.GetHierarchyEditorType(hierarchyViewModel.RootResourceClassKey);

                if(type != null)
                {
                    _hierarchyEditorType = type;
                }
            }
        }
    }
}