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
using RoadRangerBackEnd.Data.Cars;
using RoadRangerBackEnd.Cars;
using System.Diagnostics;

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
            mapClass = new MapTool(googleMap);
            LoadLocation();
            InitializePresenter(googleMap,null); //Vietoj null turi ateit listas su pins'ais

        }
         async Task LoadLocation()
       {
           Position position =  await mapClass.GetLocation();
            mapClass.SetLocation(position);
           var pin = new Pin();
       }
        protected async Task InitializePresenter(Map map, List<Pin> pins)
        {
            presenter = new MapToolPresenter(this, new MapModel(map));
            //if (SetLocation != null) this.SetLocation(this, EventArgs.Empty); //Kol kas neveikia
            if (AddPins != null) this.AddPins(this, new PinsEventArgs() {Map = map, Pins = pins });
        }

    }
}