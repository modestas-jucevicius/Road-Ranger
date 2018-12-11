using Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using Models.Statistics;

namespace WebAPI.Services.Statistic.Statistics
{
    public class CarDateStatistic : BaseStatistic, IStatistic
    {
        public List<StatisticEntry> Get(List<CapturedCar> cars)
        {
            return cars.GroupBy(x => (new DateTime(1970, 1, 1) + TimeSpan.FromMilliseconds(x.Image.Timestamp * 1000)).Hour)
                .Select(y => new StatisticEntry()
                {
                    Label = y.Key.ToString(),
                    Value = y.Count(),
                    Color = color.GetRandom()
                }).ToList();
        }
    }
}
