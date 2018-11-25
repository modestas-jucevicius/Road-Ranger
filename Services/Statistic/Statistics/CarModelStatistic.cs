using Models.Cars;
using Services.Statistic.Color;
using System.Collections.Generic;
using System.Linq;

namespace Services.Statistic.Statistics
{
    public class CarModelStatistic : IStatistic
    {
        private IColor color = new HexColor();
        public List<StatisticEntry> Get(List<CapturedCar> cars, CarStatus status)
        {
            return cars.Where(x => (x.Status & status) != 0)
                .GroupBy(x => x.Model)
                .Select(y => new StatisticEntry(y.Key.ToString(), y.Count(), color.GetRandom())).ToList();
        }
    }
}
