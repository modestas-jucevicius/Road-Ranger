using System.Collections.Generic;
using Microcharts;
using Models.Cars;
using Services.Statistic.Statistics;

namespace Services.Statistic.Charts
{
    public class CarStatusChart : IChart
    {
        private IStatistic carStatusStatistic = new CarStatusStatistic();
        private StatisticEntryConverter converter;
        private CarStatus status;

        public CarStatusChart()
        {
            converter = new StatisticEntryConverter();
            status = CarStatus.NOT_STOLEN | CarStatus.STOLEN | CarStatus.STOLEN_PLATE | CarStatus.UNKNOWN;
        }

        public CarStatusChart(StatisticEntryConverter converter, CarStatus status)
        {
            this.converter = converter;
            this.status = status;
        }

        public Chart Get(List<CapturedCar> cars)
        {
            List<StatisticEntry> statisticEntries = carStatusStatistic.Get(cars, status);
            List<Microcharts.Entry> entries = converter.ToMicrochartEntries(statisticEntries);
            return new Microcharts.DonutChart { Entries = entries };
        }
    }
}
