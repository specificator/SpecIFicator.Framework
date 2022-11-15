using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels.Metadata;

namespace SpecIFicator.Framework.MetadataEditor
{
    public partial class ResourceClassBrowser
    {
        [Inject]
        private ISpecIfDataProviderFactory SpecIfDataProviderFactory { get; set; }

        [Inject]
        private IStringLocalizer<MetadataEditorPage> L { get; set; }

        private ResourceClassesViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext = new ResourceClassesViewModel(SpecIfDataProviderFactory.MetadataReader,
                                                                    SpecIfDataProviderFactory.MetadataWriter);

            DataContext.PropertyChanged += OnPropertyChanged;
        }


        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "StateChanged")
            {
                StateHasChanged();
            }
        }
    }
}