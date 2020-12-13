﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Pomodoro.Droid
{
    [Activity(Label = "SplashScreen",
        Icon = "@mipmap/icon", Theme = "@style/Splash",
        MainLauncher = true, NoHistory =true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation
        |ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]

    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}
