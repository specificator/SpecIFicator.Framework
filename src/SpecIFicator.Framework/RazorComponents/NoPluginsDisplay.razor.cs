using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.Framework.RazorComponents
{
    public partial class NoPluginsDisplay
    {
        [Inject]
        private IStringLocalizer<NoPluginsDisplay> L { get; set; }
    }
}