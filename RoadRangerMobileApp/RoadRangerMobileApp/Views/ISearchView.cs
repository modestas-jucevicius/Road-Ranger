using RoadRangerBackEnd.Cars;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RoadRangerMobileApp.Views
{
    public interface ISearchView
    {
        string SearchText { get; }
        event EventHandler<EventArgs> Search;
        event EventHandler<SelectedItemChangedEventArgs> OnItem;
        ListView ListView { get; set; }
        ObservableCollection<CapturedCar> Items { get; set; }
        Task ShowValidationDialogAlert();
        Task NavigateToCarDetailPage(CapturedCar car);
    }
}
