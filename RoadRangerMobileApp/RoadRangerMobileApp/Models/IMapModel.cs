using RoadRangerBackEnd.Maps;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace RoadRangerMobileApp.Models
{
    public interface IMapModel
    {
        Task<Position> GetLocation();
        void AddPins(List<Pin> pins, Map map);
        void SetLocation(Position position);

    }
}
