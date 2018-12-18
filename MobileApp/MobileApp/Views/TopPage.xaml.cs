using Models.Users;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TopPage : ContentPage, ITopView
	{
        public ListView ListView
        {
            get => ItemsListView;
            set => ItemsListView = value;
        }
        public ObservableCollection<User> Items
        {
            get => Items;
            set => Items = value;
        }
        public bool IsPressable
        {
            set => this.IsEnabled = value;
        }

        public Page Page => this;

        public TopPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (this.Search != null)
                Search(this, EventArgs.Empty);          
        }

        public event EventHandler<EventArgs> Search;
    }
}