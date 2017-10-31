using Android.App;
using Android.Content.PM;
using Android.OS;
using ScrabblistaPL.Android.Helpers;

namespace ScrabblistaPL.Android
{
    [Activity(Label = "Scrabblista", Icon = "@drawable/sLogo", Theme = "@style/Theme.Scrabbler", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            AssetsHelper.StaticAssets = Assets;

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}