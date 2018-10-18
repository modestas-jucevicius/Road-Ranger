using Road_rangerVS.Images;

namespace Road_rangerVS.Recognition
{
    class CapturedCar
    {
        public Car car { get; set; }
        public Image image { get; set; }
        public CapturedCar(Car car, Image image)
        {
            this.car = car;
            this.image = image;
        }

        override public string ToString()
        {
            return car.ToString() + " " + image.ToString();
        }
    }
}
