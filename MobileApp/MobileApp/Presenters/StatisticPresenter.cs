using Microcharts;
using MobileApp.Manager;
using MobileApp.Views;
using MobileApp.Services.WebAPI.Statistic;
using System;
using Xamarin.Forms;

namespace MobileApp.Presenters
{
    public class StatisticPresenter : BasePresenter
    {
        private IStatisticView view;
        private Page page;
        private StatisticService service;
        private StatisticEntryConverter converter;

        public StatisticPresenter(StatisticPage page)
        {
            view = page;
            this.page = page;
            service = StatisticService.GetInstance();
            converter = new StatisticEntryConverter();
            Initialize();
        }

        private void Initialize()
        {
            view.ChartView += new EventHandler<EventArgs>(ChartView);
        }

        private async void ChartView(object sender, EventArgs e)
        {
            try
            {
                view.Chart1 = new RadarChart { Entries = converter.ToMicrochartEntries(await service.GetEntries(0)) };
                view.Chart2 = new RadarChart { Entries = converter.ToMicrochartEntries(await service.GetEntries(1)) };
                view.Chart3 = new RadarChart { Entries = converter.ToMicrochartEntries(await service.GetEntries(2)) };
                view.Chart4 = new RadarChart { Entries = converter.ToMicrochartEntries(await service.GetEntries(3)) };
            }
            catch (Exception ex)
            {
                await DialogAlertManager.ShowInternalDialogAlert(page);
            }
        }
    }
}
