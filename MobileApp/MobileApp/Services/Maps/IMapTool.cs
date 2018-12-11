using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace MobileApp.Services.Maps
{
    public interface IMapTool
    {
         Task<Position> GetLocation();
        void AddPins(List<Pin> pins, Map map);
        void SetLocation(Position position);

    }
}
