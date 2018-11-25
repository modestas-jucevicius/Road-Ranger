using Models.Cars;

namespace MobileApp.Models
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
