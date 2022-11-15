using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.ViewModels.Metadata;
using MDD4All.SpecIF.DataProvider.Contracts;

namespace SpecIFicator.Framework.MetadataEditor
{
    public partial class StatementClassBrowser
    {
        [Inject]
        private ISpecIfDataProviderFactory SpecIfDataProviderFactory { get; set; }

        [Inject]
        private IStringLocalizer<MetadataEditorPage> L { get; set; }

        private StatementClassesViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext = new StatementClassesViewModel(SpecIfDataProviderFactory.MetadataReader,
                                                        SpecIfDataProviderFactory.MetadataWriter);
        }
    }
}