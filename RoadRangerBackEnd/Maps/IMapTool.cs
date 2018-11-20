using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace RoadRangerBackEnd.Maps
{
    public interface IMapTool
    {
         Task<Position> GetLocation();
        void AddPins(List<Pin> pins, Map map);
        void SetLocation(Position position);

    }
}
