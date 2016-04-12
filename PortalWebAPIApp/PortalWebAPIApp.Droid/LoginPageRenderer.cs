using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PortalWebAPIApp.Droid;
using PortalWebAPIApp;
using Xamarin.Auth;
using StudioDonder.OAuth2.Mobile;
using PortalWebAPIApp.services;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace PortalWebAPIApp.Droid
{
    public class LoginPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);


            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;
            LoginPage loginPage = this.Element as LoginPage;
            loginPage.LoggedIn += Q_LoggedIn;
            //loginPage.LoginButtonClicked += LoginPage_LoginButtonClicked;


        }

        
        private void Q_LoggedIn(object sender, models.TokenResponseModel e)
        {
            //moved to AccountService with dependency injection

            //string serviceID = this.Context.ApplicationInfo.LoadLabel(this.Context.PackageManager);
            //Account acc = new Account(e.UserName);
            //acc.Properties.Add("TokenResponseResult", UtilityService.SerializeJson(e));
            //AccountStore.Create(this.Context).Save(acc, serviceID);
            ////App.SaveToken(e.AccessToken);

        }

        
    }
    
}