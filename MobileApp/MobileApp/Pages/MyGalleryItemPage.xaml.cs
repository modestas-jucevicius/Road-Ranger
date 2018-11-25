using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyGalleryItemPage : ContentPage, IMyGalleryItemView
    {
        public MyGalleryItemPage()
        {
            InitializeComponent();
        }

        void RemoveItem_Clicked(object sender, EventArgs e)
        {
            if (this.Remove != null)
                Remove(this, EventArgs.Empty);
        }

        void ReportItem_Clicked(object sender, SelectedItemChangedEventArgs args)
        {
            if (this.Report != null)
                Report(this, EventArgs.Empty);
        }

        public async Task ClosePage()
        {
            await Navigation.PopAsync();        // uždaro šitą page
            OnAppearing();                      // atnaujina list'a
        }

        public event EventHandler<EventArgs> Remove;
        public event EventHandler<EventArgs> Report;
    }
}