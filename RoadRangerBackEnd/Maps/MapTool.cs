using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RoadRangerBackEnd.Maps
{
    public class MapTool : IMapTool
    {
        private Map map;

        public MapTool(Map map)
        {
            this.map = map;
        }

        public async Task<Position> GetLocation()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 30;
                var position = await locator.GetPositionAsync();
                return new Position(position.Latitude, position.Longitude);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                return new Position(0, 0);
            }
        }
        public void AddPins(List<Pin> pins, Map map)
        {
            foreach (Pin pin in pins)
            {
                if (!map.Pins.Contains(pin)) { map.Pins.Add(pin); }
            }
        }
        public void SetLocation(Position position)
        {
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, new Distance(500)));
        }
    }
}
