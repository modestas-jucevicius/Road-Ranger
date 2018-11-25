using Models.Cars;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public interface IMyGalleryView
    {
        event EventHandler<EventArgs> Add;
        event EventHandler<SelectedItemChangedEventArgs> OnItem;
        event EventHandler<EventArgs> Search;
        ListView ListView { get; set; }
        ObservableCollection<CapturedCar> Items { get; set; }
    }
}
