using System;

namespace MobileApp.Views
{
    public interface IShopView
    {
        string Score { get; set; }
        event EventHandler<EventArgs> Boost30p;
        event EventHandler<EventArgs> Boost50p;
        event EventHandler<EventArgs> BoostDouble;
    }
}
