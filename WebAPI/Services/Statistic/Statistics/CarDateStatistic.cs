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
            return cars.GroupBy(x => (new DateTime(x.Image.Timestamp)))
                .Select(y => new StatisticEntry()
                {
                    Label = y.Key.ToString(),
                    Value = y.Count(),
                    Color = color.GetRandom()
                }).ToList();
        }
    }
}
