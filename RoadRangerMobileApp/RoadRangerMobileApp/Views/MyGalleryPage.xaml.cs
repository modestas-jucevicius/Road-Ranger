using RoadRangerMobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyGalleryPage : ContentPage
	{
        MyGalleryViewModel viewModel;

        public MyGalleryPage ()
		{
			InitializeComponent();

            BindingContext = viewModel = new MyGalleryViewModel();
        }
	}
}