using Models.Cars;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage, ISearchView
    {
        public SearchPage()
        {
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
        public bool IsPressable
        {
            set => this.IsEnabled = value;
        }

        public Page Page => this;

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (this.OnItem != null)
                OnItem(this, args);
        }

        void Search_Clicked(object sender, EventArgs e)
        {
            ItemsListView.SelectedItem = null;
            if (this.Search != null)
                Search(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> Search;
        public event EventHandler<SelectedItemChangedEventArgs> OnItem;
    }
}