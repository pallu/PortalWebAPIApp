using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PortalWebAPIApp
{
    public class ProfilePage : BaseContentPage
    {
        public ProfilePage()
        {
            //Content = new StackLayout
            //{
            //    Children = {
            //        new Label { Text = "Hello ContentPage" }
            //    }
            //};
            Content = new Label()
            {
                Text = "Profile Page",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
        }
    }
}
