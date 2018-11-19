using RoadRangerMobileApp.ViewModels;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopPage : ContentPage
    {
        public MyShopViewModel viewModel;// = new MyShopViewModel();

        public ShopPage()
        {
            InitializeComponent();
            //viewModel = new MyShopViewModel();
        }

        private void Boost30p_Clicked(object sender, EventArgs args)
        {

            //MessagingCenter.Send(this, "Boost30p");

            if(this.viewModel == null)
            {
                this.viewModel = new MyShopViewModel();
            }
            this.viewModel.BuyBoost30p();
        }

        private void Boost50p_Clicked(object sender, EventArgs args)
        {
            if (this.viewModel == null)
            {
                this.viewModel = new MyShopViewModel();
            }
            this.viewModel.BuyBoost50p();
        }
    
        private void BoostDouble_Clicked(object sender, EventArgs args)
        {
            if (this.viewModel == null)
            {
                this.viewModel = new MyShopViewModel();
            }
            this.viewModel.BuyBoostDouble();
        }
    }
}
