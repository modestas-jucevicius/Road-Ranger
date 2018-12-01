using Microcharts;
using Models.Cars;
using Models.Statistics;
using System.Collections.Generic;

namespace WebAPIServices.Statistic.Statistics
{
    public interface IStatistic
    {
        List<StatisticEntry> Get(List<CapturedCar> cars);
    }
}
