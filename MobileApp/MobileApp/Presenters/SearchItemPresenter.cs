using MobileApp.Views;
using System;
using MobileApp.Manager;
using MobileApp.Services.WebAPI.Cars;
using MobileApp.Services.Report;
using Models.Cars;

namespace MobileApp.Presenters
{
    public class SearchItemPresenter
    {
        protected readonly CapturedCarService service = new CapturedCarService();
        private IReporter reporter = new MailReporter();
        private IReportItemView view;
        public CapturedCar Item { get; set; }

        public SearchItemPresenter(IReportItemView view, CapturedCar car)
        {
            this.view = view;
            Item = car;
            Initialize();
        }

        protected void Initialize()
        {
            view.Report += new EventHandler<EventArgs>(Report);
        }

        private async void RemoveItem()
        {
            await service.Remove(Item.Id);
        }

        async void Report(object sender, EventArgs e)
        {
            if (Item == null || Item.IsReported)
            {
                await DialogAlertManager.ShowInvalidReportDialogAlert(view.Page);
                return;
            }

            if (await DialogAlertManager.ShowReportDialog(view.Page))
            {
                reporter.SendGeneretedMail(Item);
                await DialogAlertManager.ShowReportWasSentAlert(view.Page);
            }
        }
    }
}
