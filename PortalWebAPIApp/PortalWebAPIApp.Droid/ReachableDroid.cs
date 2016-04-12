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
using Android.Net;
using PortalWebAPIApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ReachableDroid))]
namespace PortalWebAPIApp.Droid
{
    public class ReachableDroid : PortalWebAPIApp.helpers.IReachability
    {
        ConnectivityManager connectivityManager;
        public ReachableDroid()
        {
            connectivityManager = Android.App.Application.Context.GetSystemService(Android.App.Activity.ConnectivityService) as ConnectivityManager;
        }
        public bool IsConnectedToNetwork()
        {
            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            return (activeConnection != null) && activeConnection.IsConnected;
        }

        public bool IsConnectedToWifi()
        {
            NetworkInfo activeNetwork = connectivityManager.ActiveNetworkInfo;
            return (activeNetwork != null) && (activeNetwork.IsConnected) && (activeNetwork.Type == ConnectivityType.Wifi);
        }

        public bool IsRoaming()
        {
            NetworkInfo activeNetwork = connectivityManager.ActiveNetworkInfo;
            return (activeNetwork != null) && (activeNetwork.IsConnected) && (activeNetwork.IsRoaming);
        }
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);
        //    connectivityManager = (ConnectivityManager)GetSystemService(Android.App.Activity.ConnectivityService);
        //}
    }
}