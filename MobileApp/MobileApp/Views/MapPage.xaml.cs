using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using MobileApp.Services.Maps;

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
        private async void LoadLocation()
        {
            MapTool tool = new MapTool(googleMap);
            Position pos = await tool.GetLocation();
            tool.SetLocation(pos);
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