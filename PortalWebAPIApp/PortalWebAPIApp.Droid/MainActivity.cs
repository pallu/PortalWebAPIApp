﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PortalWebAPIApp.Droid
{
    [Activity(Label = "PortalWebAPIApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //
            Xamarin.Forms.DependencyService.Register<Plugin.Toasts.ToastNotificatorImplementation>();
            Plugin.Toasts.ToastNotificatorImplementation.Init(this);

            //
            LoadApplication(new App());
        }
    }
}

