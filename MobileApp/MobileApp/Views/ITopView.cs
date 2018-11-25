using Models.Users;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public interface ITopView
    {
        ListView ListView { get; set; }
        ObservableCollection<User> Items { get; set; }
        event EventHandler<EventArgs> Search;
    }
}
