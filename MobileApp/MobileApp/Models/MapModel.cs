using Services.Maps;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace MobileApp.Models
{
    public class MapModel : IMapModel
    {
        private readonly IMapTool mapTool;
        public MapModel(Map map)
        {
            this.mapTool = new MapTool(map);
        }

        public void AddPins(Map map)
        {
            List<Pin> pins = new List<Pin>();
            CarsToPinsConverter.ConvertToPins(pins);
            mapTool.AddPins(pins, map);
        }
    }
}
