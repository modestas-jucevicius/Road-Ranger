using RoadRangerBackEnd.Cars;
using RoadRangerMobileApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyGalleryPage : ContentPage
	{
        private MyGalleryViewModel viewModel;

        public MyGalleryPage ()
		{
			InitializeComponent();

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

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddStolenCarPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (viewModel.Items.Count == 0)
            Console.WriteLine("OnAppearing");
            viewModel.LoadItemsCommand.Execute(null);
        }

    }
}