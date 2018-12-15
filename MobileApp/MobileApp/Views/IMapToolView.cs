using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MobileApp.Views
{
    public interface IMapToolView
    {
        Page Page { get; }
        Map GoogleMap { get; set; }
    }
}
