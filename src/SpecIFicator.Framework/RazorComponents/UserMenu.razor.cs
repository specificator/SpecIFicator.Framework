using MDD4All.SpecIF.DataProvider.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.Framework.RazorComponents
{
    public partial class UserMenu
    {
        [Inject]
        private IStringLocalizer<UserMenu> L { get; set; }

        [Inject]
        private ISpecIfDataProviderFactory SpecIfDataProviderFactory { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private bool _show = false;

        private async Task OutFocus()
        {
            await Task.Delay(200);
            _show = false;
        }

        private void OnLogoutClick()
        {
            SpecIfDataProviderFactory.MetadataReader = null;

            NavigationManager.NavigateTo("/");
        }
    }
}