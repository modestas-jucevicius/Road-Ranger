using RoadRangerBackEnd.Cars;
using System;
using System.Collections.Generic;

namespace RoadRangerBackEnd.Statistic
{
    public class CarLocationStatistic : IStatistic
    {
        private IColor color = new HexColor();
        public List<StatisticEntry> Get(List<CapturedCar> cars, CarStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
