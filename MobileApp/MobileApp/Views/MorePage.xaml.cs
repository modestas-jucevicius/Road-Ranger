using System;
using MobileApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MorePage : ContentPage, IMoreView
    {
        public MorePage ()
		{
			InitializeComponent ();
		}

        public bool IsPressable
        {
            set => this.IsEnabled = value;
        }

        public Page Page => this;

        private void MyGalleryButton_Clicked(object sender, EventArgs args)
        {
            MyGalleryClick(this, args);
        }

        private void MapButton_Clicked(object sender, EventArgs args)
        {
            MapClick(this, args);
        }

        private void StatsButton_Clicked(object sender, EventArgs args)
        {
            StatsClick(this, args);
        }

        private void ReportButton_Clicked(object sender, EventArgs args)
        {
            ReportClick(this, args);
        }

        public event EventHandler<EventArgs> MyGalleryClick;
        public event EventHandler<EventArgs> MapClick;
        public event EventHandler<EventArgs> StatsClick;
        public event EventHandler<EventArgs> ReportClick;
    }
}