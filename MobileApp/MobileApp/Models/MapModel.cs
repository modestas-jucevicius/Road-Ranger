using Models.Cars;
using Services.Maps;
using Services.WebAPI.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;
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
