using Models.Cars;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public interface ISearchView
    {
        string SearchText { get; }
        bool IsPressable { set; }
        Page Page { get; }
        event EventHandler<EventArgs> Search;
        event EventHandler<SelectedItemChangedEventArgs> OnItem;
        ListView ListView { get; set; }
        ObservableCollection<CapturedCar> Items { get; set; }
    }
}
