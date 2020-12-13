
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Pomodoro.Droid
{
    [Activity(Label = "Pomodoro",
        Icon = "@mipmap/ic_pomodoro", Theme = "@style/Theme.Splash",
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
