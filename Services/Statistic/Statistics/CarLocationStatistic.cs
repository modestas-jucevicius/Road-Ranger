using Models.Cars;
using Services.Statistic.Color;
using System;
using System.Collections.Generic;

namespace Services.Statistic.Statistics
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
