using Android.App;
using Android.OS;

namespace ScrabblistaPL.Android
{
    [Activity(Theme = "@style/Theme.SplashScreen", MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            StartActivity(typeof(MainActivity));
        }
    }
}