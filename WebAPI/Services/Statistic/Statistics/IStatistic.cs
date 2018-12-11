using Microcharts;
using Models.Cars;
using Models.Statistics;
using System.Collections.Generic;

namespace WebAPI.Services.Statistic.Statistics
{
    public interface IStatistic
    {
        List<StatisticEntry> Get(List<CapturedCar> cars);
    }
}
