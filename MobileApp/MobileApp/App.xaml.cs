using MobileApp.Manager;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileApp
{
    public partial class App : Application, IApp
    {
        public App()
        {
            InitializeComponent();
            NavigationManager.GetInstance().NavigateToMain(this);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        Page IApp.Main
        {
            set
            {
                MainPage = value;
            }
        }
    
    }
}
