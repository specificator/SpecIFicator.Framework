using Microsoft.AspNetCore.Components;
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

                HierarchyEditorViewModel hierarchyEditorViewModel = new HierarchyEditorViewModel(DataProviderFactory.MetadataReader,
                                                                               DataProviderFactory.DataReader,
                                                                               DataProviderFactory.DataWriter,
                                                                               key);
                

                _dataContext.HierarchyEditorViewModel = hierarchyEditorViewModel;

                Type type = DynamicConfigurationManager.GetComponentType("HierarchyEditor", 
                                                                         "SpecIFicator",
                                                                         hierarchyEditorViewModel.RootNode.RootResourceClassKey);

                if(type != null)
                {
                    _hierarchyEditorType = type;
                }
            }
        }
    }
}