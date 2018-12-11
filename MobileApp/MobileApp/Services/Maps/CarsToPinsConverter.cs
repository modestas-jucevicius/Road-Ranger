using Models.Cars;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace MobileApp.Services.Maps
{
    public class CarsToPinsConverter
    {
        public static void ConvertToPins(List<Pin> pins, List<CapturedCar> cars)
        {
            foreach (CapturedCar car in cars)
            {
             //   if (car.Status == CarStatus.STOLEN || car.Status == CarStatus.STOLEN_PLATE)
             //   {
                    Pin pin = new Pin();
                    pin.Label = car.LicensePlate;
                    pin.Position = car.Image.Position;
                    pins.Add(pin);
               // }
            }
        }
    }
}
