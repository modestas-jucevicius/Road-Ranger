using RoadRangerBackEnd.Cars;
using System.Collections.Generic;
using System.Linq;

namespace RoadRangerBackEnd.Statistic
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
