using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public interface ILoginView
    {
		string Username { get; }
		string Password { get; }
        bool IsPressable { set; }
        Page page { get; }
		event EventHandler<RegisterEventArgs> OnRegister;
		event EventHandler<LoginEventArgs> OnLogin;
    }
}
