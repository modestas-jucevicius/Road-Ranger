using Xamarin.Forms;

namespace MobileApp.Views
{
    public interface IBaseView
    {
        bool IsPressable { set; }
        Page Page { get; }
    }
}
