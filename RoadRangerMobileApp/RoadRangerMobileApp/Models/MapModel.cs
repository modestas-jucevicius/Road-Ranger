using RoadRangerBackEnd.Maps;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace RoadRangerMobileApp.Models
{
    public class MapModel : IMapModel
    {
        private readonly IMapTool mapTool;
        public MapModel(Map map)
        {
            this.mapTool = new MapTool(map);
        }
        public async Task<Position> GetLocation()
        {
            Position position = await mapTool.GetLocation();
            return  mapTool.GetLocation().Result;
        }
        public void AddPins(List<Pin> pins, Map map)
        {
            mapTool.AddPins(pins, map);
        }
        public void SetLocation(Position position)
        {
            mapTool.SetLocation(position);
        }
    }
}
