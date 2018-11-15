using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Search;
using RoadRangerBackEnd.Statistic;
using RoadRangerBackEnd.Statistic.Charts;
using RoadRangerMobileApp.Views;
using System;
using System.Collections.Generic;

namespace RoadRangerMobileApp.Presenters
{
    public class StatisticPresenter : BasePresenter
    {
        private StatisticEntryConverter converter = new StatisticEntryConverter();
        private readonly ICapturedCarFinder finder = new CapturedCarFinder();

        private CarStatus status = CarStatus.NOT_STOLEN | CarStatus.STOLEN | CarStatus.STOLEN_PLATE | CarStatus.UNKNOWN;

        private IChart carDateChart;
        private IChart carYearChart;
        //private IChart carLocationChart = new CarLocationChart();
        private IChart carModelChart;
        private IChart carStatusChart = new CarStatusChart();

        private IStatisticView view;

        public StatisticPresenter(IStatisticView view)
        {
            this.view = view;
            this.Initialize();
            this.InitializeCharts();
        }

        private void Initialize()
        {
            this.view.ChartView += new EventHandler<EventArgs>(ChartView);
        }

        private void InitializeCharts()
        {
            carDateChart = new CarDateChart(converter, status);
            carYearChart = new CarYearChart(converter, status);
            //carLocationChart = new CarLocationChart(converter, status);
            carModelChart = new CarModelChart(converter, status);
            carStatusChart = new CarStatusChart(converter, status);
        }

        void ChartView(object sender, EventArgs e)
        {
            lock (loadLock)
            {
                List<CapturedCar> cars = finder.FindAll();

                this.view.Chart1 = carDateChart.Get(cars);
                this.view.Chart2 = carYearChart.Get(cars);
                //this.view.Chart3 = carLocationChart.Get(cars);
                this.view.Chart4 = carModelChart.Get(cars);
                this.view.Chart5 = carStatusChart.Get(cars);
            }
        }

    }
}
