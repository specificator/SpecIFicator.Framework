using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels.Metadata;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataModels.Manipulation;

namespace SpecIFicator.Framework.MetadataEditor
{
    public partial class PropertyClassEditor
    {

        [Parameter]
        public PropertyClassesViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            if (DataContext.DataTypes.Any())
            {
                DataTypeViewModel firstElement = DataContext.DataTypes.First();

                Key key = new Key();
                key.InitailizeFromKeyString(firstElement.KeyString);


                DataContext.PropertyClassUnderEdit.DataTypeKey = key;
            }

        }

        private async Task OnTypeSelectionChanged(ChangeEventArgs args)
        {
            string selection = args.Value.ToString();
            if (!string.IsNullOrEmpty(selection))
            {
                Key key = new Key();
                key.InitailizeFromKeyString(selection);
                DataContext.PropertyClassUnderEdit.DataTypeKey = key;


            }
        }
    }
}
