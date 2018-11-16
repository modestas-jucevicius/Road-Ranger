using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoadRangerBackEnd.Users;
using RoadRangerMobileApp.Presenters;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TopPage : ContentPage, ITopView
	{
        private TopPresenter presenter;

		public TopPage ()
		{
			InitializeComponent();
            BindingContext = presenter = new TopPresenter(this);
		}

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
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (this.Search != null)
            {
                this.Search(this, EventArgs.Empty);
            }              
        }

        public event EventHandler<EventArgs> Search;
    }
}