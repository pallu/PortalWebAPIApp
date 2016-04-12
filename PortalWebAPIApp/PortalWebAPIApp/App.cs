using PortalWebAPIApp.models;
using PortalWebAPIApp.services;
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
            get { return !string.IsNullOrWhiteSpace(Token); }
        }

        //static string _Token;
        public static string Token
        {
            get {
                if (TokenResponseModel != null)
                    return TokenResponseModel.AccessToken;
                else
                    return null;
                //return _Token;
            }
        }
        //public static void SaveToken(string token)
        //{
        //    _Token = token;
        //}

        static TokenResponseModel _tokenResponseModel;
        public static TokenResponseModel TokenResponseModel
        {
            get {
                CheckRefresh();
                return _tokenResponseModel;
            }
        }
        public static void SaveTokenResponseModel(TokenResponseModel trm)
        {
            _tokenResponseModel = trm;
            CheckRefresh();
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
            var trm = DependencyService.Get<ILoginStoreService>().GetToken();
            if(trm!=null)
            {
                //App.SaveToken(trm.AccessToken);
                App.SaveTokenResponseModel(trm);
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        private static void CheckRefresh()
        {
            if (_tokenResponseModel != null && _tokenResponseModel.ExpiresUTC.HasValue && (DateTime.Now.ToUniversalTime() > _tokenResponseModel.ExpiresUTC.Value))
            {
                var trmTask = new AccountsService().RefreshToken(_tokenResponseModel.RefreshToken);
                _tokenResponseModel = trmTask.Result;
            }
        }
    }
}
