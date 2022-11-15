using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels.Metadata;

namespace SpecIFicator.Framework.MetadataEditor
{
    public partial class DataTypesBrowser
    {
        [Inject]
        private ISpecIfDataProviderFactory SpecIfDataProviderFactory { get; set; }

        [Inject]
        private IStringLocalizer<MetadataEditorPage> L { get; set; }

        private DataTypesViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext = new DataTypesViewModel(SpecIfDataProviderFactory.MetadataReader);
        }
    }
}