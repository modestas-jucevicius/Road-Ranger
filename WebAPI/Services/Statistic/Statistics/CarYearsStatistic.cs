using Models.Cars;
using Models.Statistics;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Services.Statistic.Statistics
{
    public class CarYearsStatistic : BaseStatistic, IStatistic
    {
        public List<StatisticEntry> Get(List<CapturedCar> cars)
        {
            return cars.GroupBy(x => x.Year)
                .Select(y => new StatisticEntry()
                {
                    Label = y.Key.ToString(),
                    Value = y.Count(),
                    Color = color.GetRandom()
                }).ToList();
        }
    }
}
