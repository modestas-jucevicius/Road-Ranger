
using System;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public interface IMainView
    {
        string Score { get; set; }
        bool IsPressable { set; }
        Page Page { get; }
        event EventHandler<EventArgs> SearchClick;
        event EventHandler<EventArgs> StartClick;
        event EventHandler<EventArgs> MoreClick;
        event EventHandler<EventArgs> TopClick;
        event EventHandler<EventArgs> ShopClick;
    }
}
