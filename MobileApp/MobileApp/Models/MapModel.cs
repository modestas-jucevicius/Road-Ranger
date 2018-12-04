using Services.Maps;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace MobileApp.Models
{
    public class MapModel : IMapModel
    {
        private readonly IMapTool mapTool;
        private readonly CarsToPinsConverter converter;
        public MapModel(Map map)
        {
            this.mapTool = new MapTool(map);
            converter = new CarsToPinsConverter();
        }

        public void AddPins(Map map)
        {
            List<Pin> pins = new List<Pin>();
            converter.ConvertToPins(pins);
            mapTool.AddPins(pins, map);
        }
    }
}
