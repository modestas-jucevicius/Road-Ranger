using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoadRangerMobileApp.Presenters;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage, ILoginView
	{
		private LoginPresenter presenter;

		public LoginPage ()
		{
			InitializeComponent ();
		}

		private void InitializePresenter()
		{
			if (presenter == null)
				BindingContext = presenter = new LoginPresenter(this);
		}

		string ILoginView.Username => Username.Text;
		string ILoginView.Password => Password.Text;

		void Register_Clicked(object sender, RegisterEventArgs args)
		{
			InitializePresenter();
			if (this.OnRegister != null)
				this.OnRegister(this, args);
		}

		void Login_Clicked(object sender, LoginEventArgs args)
		{
			InitializePresenter();
			if (this.OnLogin != null)
				this.OnLogin(this, args);
		}

		public async Task NavigateBack()
		{
			await Navigation.PopModalAsync();
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