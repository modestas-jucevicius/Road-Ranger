using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopPage : ContentPage, IShopView
    {
        public ShopPage()
        {
            InitializeComponent();
        }

        string IShopView.Score
        {
            get => Score.Text;
            set => Score.Text = value;
        }
        public bool IsPressable
        {
            set => this.IsEnabled = value;
        }

        public Page Page => this;

        private void Boost30p_Clicked(object sender, EventArgs args)
        {
            Boost30p(this, EventArgs.Empty);
        }

        private void Boost50p_Clicked(object sender, EventArgs args)
        {
            Boost50p(this, EventArgs.Empty);
        }
    
        private void BoostDouble_Clicked(object sender, EventArgs args)
        {
            BoostDouble(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> Boost30p;
        public event EventHandler<EventArgs> Boost50p;
        public event EventHandler<EventArgs> BoostDouble;
    }
}
