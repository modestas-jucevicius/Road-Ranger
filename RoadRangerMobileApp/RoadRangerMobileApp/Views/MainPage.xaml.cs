using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
        }

        private async void MyGalleryButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MyGalleryPage()));
        }

        private async void MapButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MapPage()));
        }

        private async void SearchButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SearchPage()));
        }

        private async void CameraButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CameraPage()));
        }

        private async void StatsButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new StatisticPage()));
        }

        private async void ReportButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ReportPage()));
        }

        private async void TopButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new TopPage()));
        }

        private async void ShopButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ShopPage()));
        }
    }
}
