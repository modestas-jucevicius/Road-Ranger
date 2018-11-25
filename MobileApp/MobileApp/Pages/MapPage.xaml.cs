using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using System;
using Services.Maps;
using Services.CustomEventArgs;
using System.Collections.Generic;

namespace MobileApp.Views
{
    //public delegate Task<string> MyDel(string str);

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage, IMapToolView
	{
        /*
        MapTool mapClass;
        private MapToolPresenter presenter;
        public event EventHandler<PinsEventArgs> AddPins;
        public event EventHandler SetLocation;
        */

        public MapPage()
        {
            InitializeComponent();
            //mapClass = new MapTool(googleMap);
            //LoadLocation();
            //InitializePresenter(googleMap,null); //Vietoj null turi ateit listas su pins'ais
        }

        /*
        async Task LoadLocation()
        {
            Position position =  await mapClass.GetLocation();
            mapClass.SetLocation(position);
            var pin = new Pin();
        }
        */

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

        /*
        protected async Task InitializePresenter(Map map, List<Pin> pins)
        {
            //presenter = new MapToolPresenter(this, new MapModel(map));    // NavigationManager naudoja
            //if(SetLocation != null) 
            //    this.SetLocation(this, EventArgs.Empty); //Kol kas neveikia
            if (AddPins != null)
                this.AddPins(this, new PinsEventArgs() { Map = map, Pins = pins });
        }
        */

        public event EventHandler<PinsEventArgs> AddPins;
        public event EventHandler SetLocation;
        
    }
}