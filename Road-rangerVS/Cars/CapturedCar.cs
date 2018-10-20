using Road_rangerVS.Images;

namespace Road_rangerVS.Recognition
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
