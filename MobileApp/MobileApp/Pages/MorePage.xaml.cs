using MobileApp.Manager;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MorePage : ContentPage
	{
		public MorePage ()
		{
			InitializeComponent ();
		}

        private async void MyGalleryButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToMyGallery(this);
        }

        private async void MapButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToMap(this);
        }

        private async void StatsButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToStatistic(this);
        }

        private async void ReportButton_Clicked(object sender, System.EventArgs e)
        {
            await NavigationManager.GetInstance().NavigateToReport(this);
        }

    }
}