using RoadRangerBackEnd.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace RoadRangerMobileApp.Views
{
    public interface ITopView
    {
        ListView ListView { get; set; }
        ObservableCollection<User> Items { get; set; }
        event EventHandler<EventArgs> Search;
    }
}
