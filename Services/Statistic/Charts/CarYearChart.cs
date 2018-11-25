using System.Collections.Generic;
using Microcharts;
using Models.Cars;
using Services.Statistic.Statistics;

namespace Services.Statistic.Charts
{
    public class CarYearChart : IChart
    {
        private IStatistic carYearStatistic = new CarYearsStatistic();
        private StatisticEntryConverter converter;
        private CarStatus status;

        public CarYearChart()
        {
            converter = new StatisticEntryConverter();
            status = CarStatus.NOT_STOLEN | CarStatus.STOLEN | CarStatus.STOLEN_PLATE | CarStatus.UNKNOWN;
        }

        public CarYearChart(StatisticEntryConverter converter, CarStatus status)
        {
            this.converter = converter;
            this.status = status;
        }
        public Chart Get(List<CapturedCar> cars)
        {
            List<StatisticEntry> statisticEntries = carYearStatistic.Get(cars, status);
            List<Entry> entries = converter.ToMicrochartEntries(statisticEntries);
            return new DonutChart { Entries = entries };
        }
    }
}
