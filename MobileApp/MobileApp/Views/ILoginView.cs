using System;
using System.Threading.Tasks;

namespace MobileApp.Views
{
    public interface ILoginView
    {
		string Username { get; }
		string Password { get; }
		event EventHandler<RegisterEventArgs> OnRegister;
		event EventHandler<LoginEventArgs> OnLogin;
    }
}
