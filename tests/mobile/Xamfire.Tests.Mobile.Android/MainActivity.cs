﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Xamfire.Tests.Mobile.Droid
{
    [Activity(Label = "Xamfire.Tests.Mobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamfire.Android.Xamfire.Initialization(this);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());

           
        }
    }
}