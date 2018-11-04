
using Road_rangerVS.Models;
using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Search;
using RoadRangerMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CapturedCarDetailPage : ContentPage
	{
        private readonly GalleryModel galleryModel = new GalleryModel();
        private readonly ReportModel reportModel = new ReportModel();
        private ICapturedCarFinder finder = new CapturedCarFinder();
        private CapturedCarDetailViewModel viewModel;

        public CapturedCarDetailPage()
        {
            InitializeComponent();
        }

        public CapturedCarDetailPage(CapturedCarDetailViewModel viewModel) : this()
		{
            BindingContext = this.viewModel = viewModel;
        }

        async void RemoveItem_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Item == null)
            {
                await DisplayAlert("Remove", "You can not remove this car!", "OK");
                return;
            }

            if (await ShowRemoveDialog())
            {
                RemoveItem();
                await Navigation.PopAsync();    // uždaro šitą page
                OnAppearing();                  // atnaujina list'a
            }
        }

        private void RemoveItem()
        {
            List<CapturedCar> cars = finder.FindAll();
            galleryModel.RemoveCarById(viewModel.Item.Id);

            if (cars.Where(x => x.Image.Id == viewModel.Item.Image.Id).Count() == 1)
                galleryModel.RemoveImageById(viewModel.Item.Image.Id);
        }

        async void ReportItem_Clicked(object sender, SelectedItemChangedEventArgs args)
        {
            if (viewModel.Item == null  || viewModel.Item.IsReported)
            {
                await DisplayAlert("Report", "You can not report this car!", "OK");
                return;
            }

            if (await ShowReportDialog())
            {
                reportModel.SendGeneratedMail(viewModel.Item);
            }
        }

        async Task<bool> ShowReportDialog()
        {
            var answer = await DisplayAlert("Report", "Would you like to report a car?", "Yes", "No");
            return answer;
        }

        async Task<bool> ShowRemoveDialog()
        {
            var answer = await DisplayAlert("Remove", "Are you sure you want to reamove this car?", "Yes", "No");
            return answer;
        }
    }
}