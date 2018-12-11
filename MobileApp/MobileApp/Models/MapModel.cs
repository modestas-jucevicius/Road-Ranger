using Models.Cars;
using MobileApp.Services.Maps;
using MobileApp.Services.WebAPI.Cars;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace MobileApp.Models
{
    public class MapModel : IMapModel
    {
        private readonly IMapTool mapTool;
        private CapturedCarService service;
        public MapModel(Map map)
        {
            mapTool = new MapTool(map);
            service = new CapturedCarService();
        }

        public async void AddPins(Map map)
        {
            List<Pin> pins = new List<Pin>();
            List<CapturedCar> cars = await service.GetAll();
            CarsToPinsConverter.ConvertToPins(pins, cars);
            mapTool.AddPins(pins, map);
        }
    }
}
