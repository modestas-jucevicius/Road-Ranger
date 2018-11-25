using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraPage : ContentPage
	{
        public static Button cameraButton = new Button
        {
            Text = "Start camera",
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };

        public void CreateButton()
        {
            var layout = new StackLayout();

            layout.Children.Add(cameraButton);
            layout.Spacing = 10;
            Content = layout;
        }

        public CameraPage ()
		{
            InitializeComponent ();
            CreateButton();
        }
    }
}