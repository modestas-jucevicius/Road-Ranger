using Models.Cars;
using Services.WebAPI.Cars;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace Services.Maps
{
    public class CarsToPinsConverter
    {   
        public static async void ConvertToPins(List<Pin> pins)
        {
            CapturedCarService service = new CapturedCarService();
             var cars = await service.GetAll();
             foreach (var car in cars)
             {
                 if (car.Status == Models.Cars.CarStatus.STOLEN || car.Status == Models.Cars.CarStatus.STOLEN_PLATE)
                 {
                     Pin pin = new Pin();
                     pin.Label = car.LicensePlate;
                     pin.Position = car.Image.position;
                     pins.Add(pin);
                 }
             }
        }
    }
}
