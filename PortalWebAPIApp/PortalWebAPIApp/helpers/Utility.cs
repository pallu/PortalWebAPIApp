using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PortalWebAPIApp.helpers
{
    public class Utility
    {
        internal static async void ShowToast(string message)
        {
            var notificator = DependencyService.Get<Plugin.Toasts.IToastNotificator>();
            bool tapped = await notificator.Notify(Plugin.Toasts.ToastNotificationType.Error,
                "Error", message, TimeSpan.FromSeconds(2));
        }
    }
}
