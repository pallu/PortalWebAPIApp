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

            if (!App.IsLoggedIn)
            {
                Navigation.PushModalAsync(new LoginPage());
            }
        }
    }
}
