using RoadRangerMobileApp.Models;
using RoadRangerMobileApp.Presenters;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchItemPage : ContentPage, IReportItemView
    {
        private ICarDetailModel model;
        private SearchItemPresenter presenter;

        public SearchItemPage()
        {
            InitializeComponent();
        }

        public SearchItemPage(ICarDetailModel model) : this()
        {
            BindingContext = this.model = model;
        }

        private void InitializePresenter()
        {
            if (this.presenter == null)
                this.presenter = new SearchItemPresenter(this, this.model);
        }

        void ReportItem_Clicked(object sender, SelectedItemChangedEventArgs args)
        {
            InitializePresenter();
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

        public event EventHandler<EventArgs> Report;
    }
}