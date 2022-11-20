using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.Framework.Shared
{
    public partial class NavMenu
    {
        [Inject]
        private IStringLocalizer<NavMenu> L { get; set; }
    }
}
