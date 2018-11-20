using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RoadRangerBackEnd.Authorization;
using System;

namespace RoadRangerMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
		private readonly AuthorizationService authorization = AuthorizationService.GetInstance();
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
			redirectToLogin();
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

		private async void redirectToLogin()
		{
			string token = await SecureStorage.GetAsync("authToken");
			if (token != null)
			{
				try
				{
					authorization.SetToken(token);
					await authorization.GetCurrentUser();
				}
				catch (Exception ex)
				{
					await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
				}
			}
			else
			{
				await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
			}
		}
    }
}
