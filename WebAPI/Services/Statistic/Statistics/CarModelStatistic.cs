using Models.Cars;
using System.Collections.Generic;
using System.Linq;
using Models.Statistics;

namespace WebAPI.Services.Statistic.Statistics
{
    public class CarModelStatistic : BaseStatistic, IStatistic
    {
        public List<StatisticEntry> Get(List<CapturedCar> cars)
        {
            return cars.GroupBy(x => x.Model)
                .Select(y => new StatisticEntry()
                {
                    Label = y.Key.ToString(),
                    Value = y.Count(),
                    Color = color.GetRandom()
                }).ToList();
        }
    }
}
