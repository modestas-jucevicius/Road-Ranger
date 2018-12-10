using MobileApp.Manager;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public partial class MainPage : ContentPage, IMainView
    {
        
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
        }

        string IMainView.Score
        {
            get => Score.Text;
            set => Score.Text = value;
        }

        private async void SearchButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToSearch(this);
        }

        private async void ShareButton_Clicked(object sender, System.EventArgs e)
        {
            await DialogAlertManager.GetInstance().ShowInternalDialogAlert(this);
        }

        private async void CameraButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToCamera(this);
        }

        private async void MoreButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToMore(this);
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
