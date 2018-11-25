using Models.Cars;
using System.Collections.Generic;

namespace Services.Statistic.Statistics
{
    public interface IStatistic
    {
        List<StatisticEntry> Get(List<CapturedCar> cars, CarStatus status);
    }
}
