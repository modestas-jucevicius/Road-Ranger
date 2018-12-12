using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Models.Cars;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyGalleryPage : ContentPage, IMyGalleryView
    {
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

        public MyGalleryPage()
		{
			InitializeComponent();
        }

        void OnItemSelected_Clicked(object sender, SelectedItemChangedEventArgs args)
        {
            if (this.OnItem != null)
                OnItem(this, args);
        }

        void AddItem_Clicked(object sender, EventArgs e)
        {
            ItemsListView.SelectedItem = null;
            if (this.Add != null)
                Add(this, EventArgs.Empty);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (this.Search != null)
                Search(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> Add;
        public event EventHandler<SelectedItemChangedEventArgs> OnItem;
        public event EventHandler<EventArgs> Search;
    }
}