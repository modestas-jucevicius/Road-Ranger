using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoadRangerMobileApp.Views
{
    interface ILoginView
    {
		string Username { get; }
		string Password { get; }
		event EventHandler<RegisterEventArgs> OnRegister;
		event EventHandler<LoginEventArgs> OnLogin;
		Task NavigateBack();
	}
}
