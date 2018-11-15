using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using RoadRangerBackEnd.Maps;
using System.Threading.Tasks;
using System.Collections.Generic;
using RoadRangerMobileApp.Presenters;
using System;
using RoadRangerMobileApp.Models;
using RoadRangerBackEnd.CustomEventArgs;

namespace RoadRangerMobileApp.Views
{
    public delegate Task<string> MyDel(string str);

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage, IMapToolView
	{
        MapTool mapClass;
        private IMapToolView view;
        private MapToolPresenter presenter;
        public event EventHandler<PinsEventArgs> AddPins;
        public event EventHandler SetLocation;
        public MapPage()
        {
            InitializeComponent();
            InitializePresenter(googleMap);
            
            
            //mapClass = new MapTool(googleMap);
            //LoadLocation();
            //List<Pin> list = new List<Pin>();
            //new Thread(() => AddPins(list,mapClass.GetMap()));

        }
        //async void LoadLocation()
        /* async Task LoadLocation()
       {
           Position position =  await mapClass.GetLocation();
           mapClass.GetMap().MoveToRegion(MapSpan.FromCenterAndRadius(position, new Distance(500)));
           var pin = new Pin();
           pin.Position = new Position(position.Latitude, position.Longitude);
           pin.Label = "Current Location";
           mapClass.GetMap().Pins.Add(pin);
       }*/
        protected async Task InitializePresenter(Map map)
        {
            presenter = new MapToolPresenter(this, new MapModel(map));
            if (SetLocation != null) this.SetLocation(this, EventArgs.Empty);
        }
        /*protected async Task InitializePresenter(Map map, List<Pin> pins)
        {
            presenter = new MapToolPresenter(this, new MapModel(map));
            if (SetLocation != null) this.SetLocation(this, EventArgs.Empty);
            if (AddPins != null) this.AddPins(this, PinsEventArgs);
        }*/

    }
}