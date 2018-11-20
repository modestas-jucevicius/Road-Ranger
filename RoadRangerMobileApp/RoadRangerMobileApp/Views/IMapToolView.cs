using RoadRangerBackEnd.CustomEventArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadRangerMobileApp.Views
{
    public interface IMapToolView
    {
        event EventHandler<PinsEventArgs> AddPins;
        event EventHandler SetLocation;
    }
}
