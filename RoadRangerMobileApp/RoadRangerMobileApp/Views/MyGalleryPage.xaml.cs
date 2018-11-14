using RoadRangerBackEnd.Cars;
using RoadRangerMobileApp.Presenters;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyGalleryPage : ContentPage, IMyGalleryView
    {
        private MyGalleryPresenter presenter;

        public ListView ListView
        {
            get => ItemsListView;
            set => ItemsListView = value;
        }
        public ObservableCollection<CapturedCar> Items
        {
            get => Items;
            set => Items = value;
        }

        public MyGalleryPage ()
		{
			InitializeComponent();
            BindingContext = presenter = new MyGalleryPresenter(this);
        }

        void OnItemSelected_Clicked(object sender, SelectedItemChangedEventArgs args)
        {
            if (this.OnItem != null)
                this.OnItem(this, args);
        }

        void AddItem_Clicked(object sender, EventArgs e)
        {
            ItemsListView.SelectedItem = null;
            if (this.Add != null)
                this.Add(this, EventArgs.Empty);
        }

        public async Task NavigateToCapturedCarDetailPage(CapturedCar car)
        {
            await Navigation.PushAsync(new MyGalleryItemPage(new CarDetailViewModel(car)));
        }

        public async Task NavigateToAddStolenCarPage()
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddStolenCarPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (this.Search != null)
                this.Search(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> Add;
        public event EventHandler<SelectedItemChangedEventArgs> OnItem;
        public event EventHandler<EventArgs> Search;
    }
}