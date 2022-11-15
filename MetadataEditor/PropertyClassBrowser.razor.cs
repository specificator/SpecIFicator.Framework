using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels.Metadata;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.Framework.MetadataEditor
{
    public partial class PropertyClassBrowser
    {
        [Inject]
        private ISpecIfDataProviderFactory SpecIfDataProviderFactory { get; set; }

        [Inject]
        private IStringLocalizer<MetadataEditorPage> L { get; set; }

        private PropertyClassesViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext = new PropertyClassesViewModel(SpecIfDataProviderFactory.MetadataReader,
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