using System;
using System.Collections.Generic;
using System.Text;

namespace RoadRangerMobileApp.Views
{
    public interface IShopView
    {
        event EventHandler<EventArgs> Boost30p;
        event EventHandler<EventArgs> Boost50p;
        event EventHandler<EventArgs> BoostDouble;
    }
}
