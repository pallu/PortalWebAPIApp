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
using PortalWebAPIApp.services;
using Xamarin.Auth;
using PortalWebAPIApp.models;
using PortalWebAPIApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(LoginStoreDroid))]
namespace PortalWebAPIApp.Droid
{
    public class LoginStoreDroid : ILoginStoreService
    {
        //public string GetPassword()
        //{
            
        //}
        public TokenResponseModel GetToken()
        {
            if (LoginExists())
            {
                var context = Xamarin.Forms.Forms.Context;
                string serviceID = context.ApplicationInfo.LoadLabel(context.PackageManager);
                var account = AccountStore.Create(context).FindAccountsForService(serviceID).Last();
                var str = account.Properties["TokenResponseResult"];
                return UtilityService.DeserializeJson<TokenResponseModel>(str);
            }
            else
                return null;
        }
        public string GetUserName()
        {
            if (LoginExists())
            {
                //var context = Xamarin.Forms.Forms.Context;
                //string serviceID = context.ApplicationInfo.LoadLabel(context.PackageManager);
                //var account = AccountStore.Create(context).FindAccountsForService(serviceID).Last();
                //var str = account.Properties["TokenResponseResult"];
                //return UtilityService.DeserializeJson<TokenResponseModel>(str).UserName;
                return GetToken().UserName;
            }
            else
                return null;
        }

        public bool LoginExists()
        {
            var context = Xamarin.Forms.Forms.Context;
            string serviceID = context.ApplicationInfo.LoadLabel(context.PackageManager);
            if (AccountStore.Create(context).FindAccountsForService(serviceID).Count() > 0)
                return true;
            else
                return false;
        }

        public void SaveLogin(TokenResponseModel trm)
        {
            var context = Xamarin.Forms.Forms.Context;
            string serviceID = context.ApplicationInfo.LoadLabel(context.PackageManager);
            Account acc = new Account(trm.UserName);
            acc.Properties.Add("TokenResponseResult", UtilityService.SerializeJson(trm));
            AccountStore.Create(context).Save(acc, serviceID);
            //if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            //{
            //    Account user = new Account { Username = userName };
            //    user.Properties.Add("Key", password);
            //    AccountStore.Create(MainActivity.Instance.BaseContext).Save(user, "Shribits");
            //}
           
        }
    }
}