using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraPage : ContentPage, ICameraView
	{
        public static Button cameraButton = new Button
        {
            Text = "Start camera",
            VerticalOptions = LayoutOptions.EndAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };

        public static Label plateLabel = new Label
        {
            Text = "Camera page",
            FontSize = 28,
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };

        public static Image cameraImage = new Image
        {
            VerticalOptions = LayoutOptions.Fill,
            Scale = 0.7
        };

        public void CreateLayout()
        {
            var layout = new StackLayout();

            layout.Children.Add(plateLabel);
            layout.Children.Add(cameraImage);
            layout.Children.Add(cameraButton);
            layout.Spacing = 10;
            Content = layout;
        }

        public CameraPage ()
		{
            InitializeComponent ();
            CreateLayout();
        }
    }
}