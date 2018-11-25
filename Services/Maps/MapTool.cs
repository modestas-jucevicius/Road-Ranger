using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Services.Maps
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
                //var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                //var position = await Geolocation.GetLocationAsync(request);
                //return new Position(position.Latitude, position.Longitude);
                return new Position(0, 0);
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
