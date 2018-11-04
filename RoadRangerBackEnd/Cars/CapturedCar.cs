using RoadRangerBackEnd.Images;

namespace RoadRangerBackEnd.Cars
{
    public class CapturedCar : Car
    {
        public Image Image { get; set; }
        public CapturedCar(Car car, Image image) : base(car)
        {
            this.Image = image;
        }
    }
}
