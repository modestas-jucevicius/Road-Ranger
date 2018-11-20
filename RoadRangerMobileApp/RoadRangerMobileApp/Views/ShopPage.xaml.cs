using RoadRangerMobileApp.Presenters;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopPage : ContentPage, IShopView
    {
        public ShopPresenter presenter;// = new MyShopViewModel();

        public ShopPage()
        {
            InitializeComponent();
            //viewModel = new MyShopViewModel();
        }

        private void InitializePresenter()
        {
            presenter = new ShopPresenter(this);
        }

        private void Boost30p_Clicked(object sender, EventArgs args)
        {
            if(presenter == null)
            {
                InitializePresenter();
            }
            Boost30p(this, EventArgs.Empty);
        }

        private void Boost50p_Clicked(object sender, EventArgs args)
        {
            if(presenter == null)
            {
                InitializePresenter();
            }
            Boost50p(this, EventArgs.Empty);
        }
    
        private void BoostDouble_Clicked(object sender, EventArgs args)
        {
            if(presenter == null)
            {
                InitializePresenter();
            }
            BoostDouble(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> Boost30p;
        public event EventHandler<EventArgs> Boost50p;
        public event EventHandler<EventArgs> BoostDouble;
    }
}
