using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using System.Diagnostics;
using Plugin.Geolocator;

namespace MobileApp.Services.Maps
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
                locator.DesiredAccuracy = 50;
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
            if (pins.Count != 0)
            {
                foreach (Pin pin in pins)
                {
                    if (!map.Pins.Contains(pin)) { map.Pins.Add(pin); }
                }
            }
        }
        public void SetLocation(Position position)
        {
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, new Distance(500)));
        }
    }
}
