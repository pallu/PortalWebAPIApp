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
        Context context;
        string serviceID;
        public LoginStoreDroid()
        {
            context = Xamarin.Forms.Forms.Context;
            serviceID = context.ApplicationInfo.LoadLabel(context.PackageManager);
            
        }
        public TokenResponseModel GetToken()
        {
            if (LoginExists())
            {
                var account = AccountStore.Create(context).FindAccountsForService(serviceID).Last();
                var str = account.Properties[Constants.TokenResponseResult];
                return UtilityService.DeserializeJson<TokenResponseModel>(str);
            }
            else
                return null;
        }
        public string GetUserName()
        {
            if (LoginExists())
            {
                return GetToken().UserName;
            }
            else
                return null;
        }

        public bool LoginExists()
        {
            if (AccountStore.Create(context).FindAccountsForService(serviceID).Count() > 0)
                return true;
            else
                return false;
        }

        public void SaveLogin(TokenResponseModel trm)
        {
            Account acc = new Account(trm.UserName);
            acc.Properties.Add(Constants.TokenResponseResult, UtilityService.SerializeJson(trm));
            AccountStore.Create(context).Save(acc, serviceID);
        }
    }
}