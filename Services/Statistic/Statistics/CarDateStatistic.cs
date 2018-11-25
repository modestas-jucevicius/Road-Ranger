using Models.Cars;
using Services.Statistic.Color;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Statistic.Statistics
{
    public class CarDateStatistic : IStatistic
    {
        private IColor color = new HexColor();
        public List<StatisticEntry> Get(List<CapturedCar> cars, CarStatus status)
        {
            return cars.Where(x => (x.Status & status) != 0)
                .GroupBy(x => (new DateTime(1970, 1, 1) + TimeSpan.FromMilliseconds(x.Image.Timestamp * 1000)).Hour)
                .Select(y => new StatisticEntry(y.Key.ToString(), y.Count(), 
                color.GetRandom())).ToList();
        }
    }
}
