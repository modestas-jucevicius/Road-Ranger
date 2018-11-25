using MobileApp.Manager;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
        }

        private async void MyGalleryButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToMyGallery(this);
        }

        private async void MapButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToMap(this);
        }

        private async void SearchButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToSearch(this);
        }

        private async void CameraButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToCamera(this);
        }

        private async void StatsButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToStatistic(this);
        }

        private async void ReportButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToReport(this);
        }

        private async void TopButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToTop(this);
        }

        private async void ShopButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToShop(this);
        }
    }
}
