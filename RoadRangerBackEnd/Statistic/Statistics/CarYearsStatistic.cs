using System.Collections.Generic;
using System.Linq;
using RoadRangerBackEnd.Cars;

namespace RoadRangerBackEnd.Statistic
{
    public class CarYearsStatistic : IStatistic
    {
        private IColor color = new HexColor();
        public List<StatisticEntry> Get(List<CapturedCar> cars, CarStatus status)
        {
            return cars.Where(x => (x.Status & status) != 0)
                .GroupBy(x => x.Year)
                .Select(y => new StatisticEntry(y.Key.ToString(), y.Count(), color.GetRandom())).ToList();
        }
    }
}
