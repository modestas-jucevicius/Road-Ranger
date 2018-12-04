using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using System;
using Services.Maps;
using Services.CustomEventArgs;
using System.Collections.Generic;
using Plugin.Geolocator;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage, IMapToolView
	{
        public MapPage()
        {
            InitializeComponent();
            LoadLocation();
        } 
        async Task LoadLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync();
            Position pos = new Position(position.Latitude, position.Longitude);
            googleMap.MoveToRegion(MapSpan.FromCenterAndRadius(pos, new Distance(500)));
            var pin = new Pin();
        }

        public Map GoogleMap
        {
            get
            {
                return googleMap;
            }
            set
            {
                googleMap = value;
            }
        }  
    }
}