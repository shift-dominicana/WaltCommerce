using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.AppCompat.App;

namespace Ecommerce.Mobile.Droid
{   
    [Activity(Theme = "@style/MainTheme.Splash",
            MainLauncher = true,
            NoHistory = true)]
    //[Activity(
    //      Theme = "@style/Theme.Splash",
    //      MainLauncher = true,
    //      NoHistory = true)]
    public class SplashActivity : Activity
    {        // Launches the startup task
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Threading.Thread.Sleep(1800);
            StartActivity(typeof(MainActivity));
        }
    }
}
