using RoadRangerMobileApp.Presenters;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyGalleryItemPage : ContentPage, IMyGalleryItemView
    {
        private CarDetailViewModel viewModel;
        private MyGalleryItemPresenter presenter;

        public MyGalleryItemPage()
        {
            InitializeComponent();
        }

        public MyGalleryItemPage(CarDetailViewModel viewModel) : this()
        {
            BindingContext = this.viewModel = viewModel;
            this.presenter = new MyGalleryItemPresenter(this, this.viewModel);
        }

        void RemoveItem_Clicked(object sender, EventArgs e)
        {
            if (this.Remove != null)
                this.Remove(this, EventArgs.Empty);
        }
        void ReportItem_Clicked(object sender, SelectedItemChangedEventArgs args)
        {
            if (this.Report != null)
                this.Report(this, EventArgs.Empty);
        }

        public async Task<bool> ShowReportDialog()
        {
            return await DisplayAlert("Report", "Would you like to report a car?", "Yes", "No");
        }

        public async Task<bool> ShowRemoveDialog()
        {
            return await DisplayAlert("Remove", "Are you sure you want to reamove this car?", "Yes", "No");
        }

        public async Task ShowInvalidRemoveDialogAlert()
        {
            await DisplayAlert("Remove", "You can not remove this car!", "OK");
        }

        public async Task ShowInvalidReportDialogAlert()
        {
            await DisplayAlert("Report", "You can not report this car!", "OK");
        }

        public async Task ClosePage()
        {
            await Navigation.PopAsync();        // uždaro šitą page
            OnAppearing();                      // atnaujina list'a
        }

        public event EventHandler<EventArgs> Remove;
        public event EventHandler<EventArgs> Report;
    }
}