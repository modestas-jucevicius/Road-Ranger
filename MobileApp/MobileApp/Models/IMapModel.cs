using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace MobileApp.Models
{
    public interface IMapModel
    {
        void AddPins(Map map);
    }
}
