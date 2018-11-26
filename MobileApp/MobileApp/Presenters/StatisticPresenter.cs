using MobileApp.Views;
using Models.Cars;
using Services.Statistic;
using Services.Statistic.Charts;
using System;
using System.Collections.Generic;
using WebService.WebService;

namespace MobileApp.Presenters
{
    public class StatisticPresenter : BasePresenter
    {
        private StatisticEntryConverter converter = new StatisticEntryConverter();
        private readonly CapturedCarService service = new CapturedCarService();

        private IChart carDateChart;
        private IChart carYearChart;
        //private IChart carLocationChart = new CarLocationChart();
        private IChart carModelChart;
        private IChart carStatusChart = new CarStatusChart();

        private IStatisticView view;
        private CarStatus status = CarStatus.NOT_STOLEN | CarStatus.STOLEN | CarStatus.STOLEN_PLATE | CarStatus.UNKNOWN;

        public StatisticPresenter(IStatisticView view)
        {
            this.view = view;
            Initialize();
            InitializeCharts();
        }

        private void Initialize()
        {
            view.ChartView += new EventHandler<EventArgs>(ChartView);
        }

        private void InitializeCharts()
        {
            carDateChart = new CarDateChart(converter, status);
            carYearChart = new CarYearChart(converter, status);
            //carLocationChart = new CarLocationChart(converter, status);
            carModelChart = new CarModelChart(converter, status);
            carStatusChart = new CarStatusChart(converter, status);
        }

        private async void ChartView(object sender, EventArgs e)
        {
            List<CapturedCar> cars = await service.GetAll();

            view.Chart1 = carDateChart.Get(cars);
            view.Chart2 = carYearChart.Get(cars);
            //view.Chart3 = carLocationChart.Get(cars);
            view.Chart4 = carModelChart.Get(cars);
            view.Chart5 = carStatusChart.Get(cars);
        }

    }
}
