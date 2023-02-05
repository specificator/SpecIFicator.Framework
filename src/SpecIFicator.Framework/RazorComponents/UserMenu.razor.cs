using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.DataProvider.Contracts.DataStreams;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace SpecIFicator.Framework.RazorComponents
{
    public partial class UserMenu
    {
        [Inject]
        private IStringLocalizer<UserMenu> L { get; set; }

        [Inject]
        private ISpecIfDataProviderFactory SpecIfDataProviderFactory { get; set; }

        [Inject]
        private ISpecIfStreamDataSubscriberProvider SpecIfStreamDataSubscriberProvider { get; set; }

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

            // stop streaming
            OnUnsubscribeClick();

            NavigationManager.NavigateTo("/");
        }

        private void OnUnsubscribeClick()
        {
            if (SpecIfStreamDataSubscriberProvider != null && SpecIfStreamDataSubscriberProvider.StreamDataSubscriber != null)
            {
                if (SpecIfStreamDataSubscriberProvider.StreamDataSubscriber is IDisposable)
                {
                    IDisposable disposable = (IDisposable)SpecIfStreamDataSubscriberProvider.StreamDataSubscriber;
                    disposable.Dispose();
                }
                SpecIfStreamDataSubscriberProvider.StreamDataSubscriber = null;
            }
        }

        //private void OnGermanClick()
        //{
        //    CultureInfo.CurrentCulture = new CultureInfo("de");
        //    CultureInfo.CurrentUICulture = new CultureInfo("de");
        //    NavigationManager.NavigateTo("/");
        //}
    }
}