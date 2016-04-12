using PortalWebAPIApp.models;
using PortalWebAPIApp.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PortalWebAPIApp
{
    public class LoginPage : ContentPage
    {
        
        Entry entryUserName;
        Entry entryPassword;
        public event EventHandler<LoginEventArgs> LoginButtonClicked;
        public event EventHandler<TokenResponseModel> LoggedIn;
        //public LoginPage()
        //{
        //    Content = new StackLayout
        //    {
        //        Children = {
        //            new Label { Text = "Hello ContentPage" }
        //        }
        //    };
        //}
        public LoginPage()
        {
            Label header = new Label
            {
                Text = "Login",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };
            Button button = new Button
            {
                Text = "Login",
                HorizontalOptions = LayoutOptions.Center
            };
            button.Clicked += Button_Clicked;

            entryUserName = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "UserName"
                //VerticalOptions = LayoutOptions.CenterAndExpand,
                //BindingContext = UserName


            };
            

            entryPassword = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Password",
                IsPassword = true,
                //VerticalOptions = LayoutOptions.CenterAndExpand,
                //BindingContext = Password
                //Text = "{Binding Password, Mode=TwoWay}"
            };
            
            
            // Build the page.
            this.Content = new ScrollView()
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        header,
                        entryUserName,
                        entryPassword,
                        button

                    }
                }
            };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            AccountsService aService = new AccountsService();
            var tokenResponseTask = aService.Login(entryUserName.Text, entryPassword.Text);
            var tokenResponse = tokenResponseTask.Result;
            App.SaveToken(tokenResponse.AccessToken);
            DependencyService.Get<ILoginStoreService>().SaveLogin(tokenResponse);
            if (LoggedIn != null)
            {
                LoggedIn(sender, tokenResponse);
            }
            App.SuccessfulLoginAction();
        }
    }
}
