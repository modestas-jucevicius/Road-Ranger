using RoadRangerBackEnd.Cars;
using RoadRangerMobileApp.Presenters;
using RoadRangerMobileApp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage, ISearchView
    {
        private SearchPresenter presenter;

        public SearchPage()
        {
            BindingContext = presenter = new SearchPresenter(this);
            InitializeComponent();
        }

        string ISearchView.SearchText => SearchLabel.Text;

        ListView ISearchView.ListView
        {
            get => ItemsListView;
            set => ItemsListView = value;
        }

        public ObservableCollection<CapturedCar> Items
        {
            get => Items;
            set => Items = value;
        }
        
        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (this.OnItem != null)
                this.OnItem(this, args);
        }

        void Search_Clicked(object sender, EventArgs e)
        {
            ItemsListView.SelectedItem = null;
            if (this.Search != null)
                this.Search(this, EventArgs.Empty);
        }

        public async Task ShowValidationDialogAlert()
        {
            await DisplayAlert("License plate", "Car license plate is not valid! License plate should be AAA000 or AA000 format.", "OK");
        }

        public async Task NavigateToCapturedCarDetailPage(CapturedCar car)
        {
            await Navigation.PushAsync(new CapturedCarDetailPage(new CapturedCarDetailViewModel(car)));
        }

        public event EventHandler<EventArgs> Search;
        public event EventHandler<SelectedItemChangedEventArgs> OnItem;
    }
}