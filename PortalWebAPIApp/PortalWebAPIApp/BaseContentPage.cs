using PortalWebAPIApp.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PortalWebAPIApp
{
    public class BaseContentPage : ContentPage
    {
        //public BaseContentPage()
        //{
        //    Content = new StackLayout
        //    {
        //        Children = {
        //            new Label { Text = "Hello ContentPage" }
        //        }
        //    };
        //}
        protected override void OnAppearing()
        {
            base.OnAppearing();


            //check if keystore or keychain content exists
            var loginExists = DependencyService.Get<ILoginStoreService>().LoginExists();
            if (!App.IsLoggedIn)
            {
                Navigation.PushModalAsync(new LoginPage());
            }
        }
    }
}
