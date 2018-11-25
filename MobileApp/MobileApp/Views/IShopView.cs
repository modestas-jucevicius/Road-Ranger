using System;

namespace MobileApp.Views
{
    public interface IShopView
    {
        event EventHandler<EventArgs> Boost30p;
        event EventHandler<EventArgs> Boost50p;
        event EventHandler<EventArgs> BoostDouble;
    }
}
