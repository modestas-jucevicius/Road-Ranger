using RoadRangerBackEnd.Cars;
using System.Collections.Generic;

namespace RoadRangerBackEnd.Statistic
{
    public interface IChart
    {
        Microcharts.Chart Get(List<CapturedCar> cars);
    }
}
