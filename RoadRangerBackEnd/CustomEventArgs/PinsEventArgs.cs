using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace RoadRangerBackEnd.CustomEventArgs
{
    public class PinsEventArgs : EventArgs
    {
        public Map map { get; }
        public List<Pin> pin { get; }
    }
}
