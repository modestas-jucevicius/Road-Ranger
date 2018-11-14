using RoadRangerBackEnd.Cars;

namespace RoadRangerMobileApp.Presenters
{
    public class CarDetailViewModel : BasePresenter
    {
        public CapturedCar Item { get; set; }
        public CarDetailViewModel(CapturedCar item = null)
        {
            Item = item;
        }
    }
}
