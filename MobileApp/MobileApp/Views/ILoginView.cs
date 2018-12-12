using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public interface ILoginView : IBaseView
    {
		string Username { get; }
		string Password { get; }
		event EventHandler<RegisterEventArgs> OnRegister;
		event EventHandler<LoginEventArgs> OnLogin;
    }
}
