using RoadRangerBackEnd.Cars;

namespace RoadRangerMobileApp.Models
{ 
    public class CarDetailModel : ICarDetailModel
    {
        public CapturedCar Item { get; set; }
        public CarDetailModel(CapturedCar item = null)
        {
            Item = item;
        }
    }
    
}
