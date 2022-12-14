using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDD4All.SpecIF.DataProvider.Contracts;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.Framework.RazorComponents
{
    public partial class UserMenu
    {
        [Inject]
        private ISpecIfDataProviderFactory SpecIfDataProviderFactory { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private bool show = false;

        private async Task OutFocus()
        {
            await Task.Delay(200);
            this.show = false;
        }

        private void OnLogoutClick()
        {
            SpecIfDataProviderFactory.MetadataReader = null;

            NavigationManager.NavigateTo("/");
        }
    }
}