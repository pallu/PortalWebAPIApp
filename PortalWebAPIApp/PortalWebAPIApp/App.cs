using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PortalWebAPIApp
{
    public class App : Application
    {
        static NavigationPage _NavPage;

        public static Page GetMainPage()
        {
            var profilePage = new ProfilePage();

            _NavPage = new NavigationPage(profilePage);

            return _NavPage;
        }

        public static bool IsLoggedIn
        {
            get { return !string.IsNullOrWhiteSpace(_Token); }
        }

        static string _Token;
        public static string Token
        {
            get { return _Token; }
        }

        public static void SaveToken(string token)
        {
            _Token = token;
        }

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() => {
                    _NavPage.Navigation.PopModalAsync();
                });
            }
        }
        public App()
        {


            // The root page of your application
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                HorizontalTextAlignment = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};
            this.MainPage = GetMainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
