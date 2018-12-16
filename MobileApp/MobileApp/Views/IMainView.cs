
using System;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public interface IMainView : IBaseView
    {
        string Score { get; set; }
        event EventHandler<EventArgs> SearchClick;
        event EventHandler<EventArgs> StartClick;
        event EventHandler<EventArgs> MoreClick;
        event EventHandler<EventArgs> TopClick;
        event EventHandler<EventArgs> ShopClick;
        event EventHandler<EventArgs> Appear;
    }
}
