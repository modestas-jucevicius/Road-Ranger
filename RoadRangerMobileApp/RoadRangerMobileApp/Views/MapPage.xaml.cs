using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using RoadRangerBackEnd.Maps;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace RoadRangerMobileApp.Views
{
    public delegate Task<string> MyDel(string str);

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
        MapClass mapClass;
		public MapPage ()
		{
            InitializeComponent();

            mapClass = new MapClass(googleMap);
            LoadLocation();
            //List<Pin> list = new List<Pin>();
            //new Thread(() => AddPins(list,mapClass.GetMap()));

        }

        //async void LoadLocation()
          async Task LoadLocation()
        {
            Position position =  await mapClass.GetLocation();
            mapClass.GetMap().MoveToRegion(MapSpan.FromCenterAndRadius(position, new Distance(500)));
            var pin = new Pin();
            pin.Position = new Position(position.Latitude, position.Longitude);
            pin.Label = "Current Location";
            mapClass.GetMap().Pins.Add(pin);
        }
        public void AddPins(List<Pin> pins, Map map)
        {
            foreach(Pin pin in pins)
            {
                if(!map.Pins.Contains(pin)) { map.Pins.Add(pin); }
            }
        }

    }
}