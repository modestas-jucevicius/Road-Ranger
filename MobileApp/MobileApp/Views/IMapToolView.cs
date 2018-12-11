using MobileApp.Services.CustomEventArgs;
using System;
using Xamarin.Forms.Maps;

namespace MobileApp.Views
{
    public interface IMapToolView
    {
        Map GoogleMap { get; set; }
    }
}
