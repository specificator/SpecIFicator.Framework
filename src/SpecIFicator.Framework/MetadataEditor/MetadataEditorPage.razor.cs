using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.Framework.MetadataEditor
{
    public partial class MetadataEditorPage
    {
        [Inject]
        private IStringLocalizer<MetadataEditorPage> L { get; set; }
    }
}