using Road_rangerVS.Images;

namespace Road_rangerVS.Recognition
{
    public class CapturedCar : Car
    {
        public Image image { get; set; }
        public CapturedCar(Car car, Image image) : base(car)
        {
            this.image = image;
        }

        override public string ToString()
        {
            return base.ToString() + " " + image.ToString();
        }
    }
}
