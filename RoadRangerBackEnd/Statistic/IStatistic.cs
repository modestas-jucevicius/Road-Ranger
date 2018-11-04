using RoadRangerBackEnd.Cars;
using System.Collections.Generic;

namespace RoadRangerBackEnd.Statistic
{
    public interface IStatistic
    {
        List<StatisticEntry> Get(List<CapturedCar> cars, CarStatus status);
    }
}
