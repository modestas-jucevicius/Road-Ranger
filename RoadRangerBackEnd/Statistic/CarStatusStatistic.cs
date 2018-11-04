using RoadRangerBackEnd.Cars;
using System.Collections.Generic;
using System.Linq;

namespace RoadRangerBackEnd.Statistic
{
    public class CarStatusStatistic : IStatistic
    {
        private IColor color = new HexColor();
        public List<StatisticEntry> Get(List<CapturedCar> cars, CarStatus status)
        {
            return cars.Where(x => (x.Status & status) != 0)
                .GroupBy(x => x.Status)
                .Select(y => new StatisticEntry(y.Key.ToString(), y.Count(), color.GetRandom())).ToList();
        }
    }
}
