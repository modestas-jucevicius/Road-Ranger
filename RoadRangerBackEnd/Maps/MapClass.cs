using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RoadRangerBackEnd.Maps
{
    public class MapClass
    {
        private Map map;
        public MapClass(Map passingMap)
        {
            map = passingMap;
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
        public Map GetMap()
        {
            return map;
        }
    }
}
