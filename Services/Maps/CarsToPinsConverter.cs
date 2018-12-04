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
        private CapturedCarService service;

        public CarsToPinsConverter()
        {
            service = new CapturedCarService();
        }
        
        public async void ConvertToPins(List<Pin> pins)
        {
             /*var cars = await service.GetAll();
             foreach (var car in cars)
             {
                 if (car.Status == Models.Cars.CarStatus.STOLEN || car.Status == Models.Cars.CarStatus.STOLEN_PLATE)
                 {
                     Pin pin = new Pin();
                     pin.Label = car.LicensePlate;
                     pin.Position = car.position;
                     pins.Add(pin);
                 }
             }*/
            Position pos = new Position(54.72911, 25.26275);
            Pin pina = new Pin();
            pina.Label = "MIFAS";
            pina.Position = pos;
            pins.Add(pina);
        }
    }
}
