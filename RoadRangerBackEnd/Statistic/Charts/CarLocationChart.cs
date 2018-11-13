
using System.Collections.Generic;
using Microcharts;
using RoadRangerBackEnd.Cars;

namespace RoadRangerBackEnd.Statistic.Charts
{
    public class CarLocationChart : IChart
    {
        private IStatistic carYearStatistic = new CarYearsStatistic();
        private StatisticEntryConverter converter;
        private CarStatus status;

        public CarLocationChart()
        {
            converter = new StatisticEntryConverter();
            status = CarStatus.NOT_STOLEN | CarStatus.STOLEN | CarStatus.STOLEN_PLATE | CarStatus.UNKNOWN;
        }

        public CarLocationChart(StatisticEntryConverter converter, CarStatus status)
        {
            this.converter = converter;
            this.status = status;
        }

        public Chart Get(List<CapturedCar> cars)
        {
            throw new System.NotImplementedException();
        }
    }
}
