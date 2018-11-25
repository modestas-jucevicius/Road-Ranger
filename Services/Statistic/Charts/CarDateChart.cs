using System.Collections.Generic;
using Microcharts;
using Models.Cars;
using Services.Statistic.Statistics;

namespace Services.Statistic.Charts
{
    public class CarDateChart : IChart
    {
        private IStatistic carDateStatistic = new CarDateStatistic();
        private StatisticEntryConverter converter;
        private CarStatus status;

        public CarDateChart()
        {
            converter = new StatisticEntryConverter();
            status = CarStatus.NOT_STOLEN | CarStatus.STOLEN | CarStatus.STOLEN_PLATE | CarStatus.UNKNOWN;
        }

        public CarDateChart(StatisticEntryConverter converter, CarStatus status)
        {
            this.converter = converter;
            this.status = status;
        }

        Chart IChart.Get(List<CapturedCar> cars)
        {
            List<StatisticEntry> statisticEntries = carDateStatistic.Get(cars, status);
            List<Entry> entries = converter.ToMicrochartEntries(statisticEntries);
            return new DonutChart { Entries = entries };
        }
    }
}
