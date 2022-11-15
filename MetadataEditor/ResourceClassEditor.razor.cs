using MDD4All.SpecIF.ViewModels.Metadata;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.Framework.MetadataEditor
{
    public partial class ResourceClassEditor
    {
        [Parameter]
        public ResourceClassesViewModel DataContext { get; set; }
    }
}