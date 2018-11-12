using RoadRangerBackEnd.Cars;
using RoadRangerMobileApp.Presenters;

namespace RoadRangerMobileApp.ViewModels
{
    public class CapturedCarDetailViewModel : BasePresenter
    {
        public CapturedCar Item { get; set; }
        public CapturedCarDetailViewModel(CapturedCar item = null)
        {
            Item = item;
        }
    }
}
