using System.Collections.Generic;
using RoadRangerBackEnd.Cars;

namespace RoadRangerBackEnd.Statistic.Charts
{
    public class CarModelChart : IChart
    {
        private IStatistic carModelStatistic = new CarModelStatistic();
        private StatisticEntryConverter converter;
        private CarStatus status;

        public CarModelChart()
        {
            converter = new StatisticEntryConverter();
            status = CarStatus.NOT_STOLEN | CarStatus.STOLEN | CarStatus.STOLEN_PLATE | CarStatus.UNKNOWN;
        }

        public CarModelChart(StatisticEntryConverter converter, CarStatus status)
        {
            this.converter = converter;
            this.status = status;
        }

        public Microcharts.Chart Get(List<CapturedCar> cars)
        {
            List<StatisticEntry> statisticEntries = carModelStatistic.Get(cars, status);
            List<Microcharts.Entry> entries = converter.ToMicrochartEntries(statisticEntries);
            return new Microcharts.DonutChart { Entries = entries };
        }
    }
}
