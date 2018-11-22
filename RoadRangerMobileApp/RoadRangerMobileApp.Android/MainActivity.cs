﻿using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Widget;
using Android.OS;
using Android;
using Xamarin.Essentials;
using RoadRangerMobileApp.Views;
using Android.Graphics;

namespace RoadRangerMobileApp.Droid
{
    [Activity(Label = "RoadRangerMobileApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestLocationId = 0;
        readonly string[] PermissionsGroupLocation =    //Leidimų masyvas - žemėlapiams reikia coarse ir fine location'ų
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation,
            Manifest.Permission.Camera,
        };
        private SurfaceTexture surface;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestPermissions(PermissionsGroupLocation, RequestLocationId);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            CameraPage.cameraButton.Clicked += (sender, args) => { StartActivity(typeof(CameraActivity)); }; //Prisiregistruojama CameraActivity prie mygtuko Clicked evento

            base.OnCreate(savedInstanceState);
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

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