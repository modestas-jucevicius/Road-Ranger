
using RoadRangerBackEnd.Cars;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RoadRangerMobileApp.Views
{
    public interface IMyGalleryView
    {
        event EventHandler<EventArgs> Add;
        event EventHandler<SelectedItemChangedEventArgs> OnItem;
        event EventHandler<EventArgs> Search;
        ListView ListView { get; set; }
        ObservableCollection<CapturedCar> Items { get; set; }
        Task NavigateToCapturedCarDetailPage(CapturedCar car);
        Task NavigateToAddStolenCarPage();
    }
}
