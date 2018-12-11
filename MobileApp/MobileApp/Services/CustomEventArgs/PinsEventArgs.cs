using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace MobileApp.Services.CustomEventArgs
{
    public class PinsEventArgs : EventArgs
    {
        public Map Map { get; set; }
        public List<Pin> Pins { get; set; }
    }
}
