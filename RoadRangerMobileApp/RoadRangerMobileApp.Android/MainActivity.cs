using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Widget;
using Android.OS;
using Android;

namespace RoadRangerMobileApp.Droid
{
    [Activity(Label = "RoadRangerMobileApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestLocationId = 0;
        readonly string[] PermissionsGroupLocation =    //Leidimų masyvas - žemėlapiams reikia coarse ir fine location'ų
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestPermissions(PermissionsGroupLocation, RequestLocationId);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            switch (requestCode)
            {
                case RequestLocationId:
                {
                    if (grantResults[0] == (int)Android.Content.PM.Permission.Granted){}
                    else
                    {
                        //Leidimas nesuteiktas
                        Toast.MakeText(this, "Location permission denied", ToastLength.Short).Show();
                    }
                }
                break;
            }
        }
    }
}