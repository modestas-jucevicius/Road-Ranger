using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyHomePage : ContentPage
	{
		public MyHomePage ()
		{
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent ();
		}

        private async void MyGalleryButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MyGalleryPage()));
        }

        private async void MyStolenCarsButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MyStolenCars()));
        }
    }
}