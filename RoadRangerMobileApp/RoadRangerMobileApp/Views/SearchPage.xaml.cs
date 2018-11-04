using RoadRangerBackEnd.Cars;
using RoadRangerMobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMobileAppExample1.Models;

namespace RoadRangerMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
        MyGalleryViewModel viewModel;
        public SearchPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new MyGalleryViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as CapturedCar;
            if (item == null)
                return;

            await Navigation.PushAsync(new CapturedCarDetailPage(new CapturedCarDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
    }
}