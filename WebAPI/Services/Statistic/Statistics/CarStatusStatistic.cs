using Models.Cars;
using System.Collections.Generic;
using System.Linq;
using Models.Statistics;

namespace WebAPI.Services.Statistic.Statistics
{
    public class CarStatusStatistic : BaseStatistic, IStatistic
    {
        public List<StatisticEntry> Get(List<CapturedCar> cars)
        {
            return cars.GroupBy(x => x.Status)
                .Select(y => new StatisticEntry()
                {
                    Label = y.Key.ToString(),
                    Value = y.Count(),
                    Color = color.GetRandom()
                }).ToList();
        }
    }
}
