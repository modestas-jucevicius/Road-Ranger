using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage, ILoginView
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		string ILoginView.Username => Username.Text;
		string ILoginView.Password => Password.Text;

		void Register_Clicked(object sender, RegisterEventArgs args)
		{
			if (this.OnRegister != null)
				OnRegister(this, args);
		}

		void Login_Clicked(object sender, LoginEventArgs args)
		{
			if (this.OnLogin != null)
				OnLogin(this, args);
		}

        public event EventHandler<RegisterEventArgs> OnRegister;
		public event EventHandler<LoginEventArgs> OnLogin;
	}

	public class RegisterEventArgs : EventArgs
	{
	}

	public class LoginEventArgs : EventArgs
	{
	}
}