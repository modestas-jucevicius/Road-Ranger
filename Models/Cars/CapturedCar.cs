using Models.Images;
using Xamarin.Forms.Maps;

namespace Models.Cars
{
    public class CapturedCar : Car
    {
        public Image Image { get; set; }
        public Position position { get; set; }
    }
}
