using MobileApp.Views;
using MobileApp.Models;
using System;
using MobileApp.Manager;
using MobileApp.Services.WebAPI.Cars;
using MobileApp.Services.Report;

namespace MobileApp.Presenters
{
    public class SearchItemPresenter
    {
        protected readonly CapturedCarService service = new CapturedCarService();
        private IReporter reporter = new MailReporter();
        private IReportItemView view;
        private ICarDetailModel model;

        public SearchItemPresenter(IReportItemView view, ICarDetailModel model)
        {
            this.view = view;
            this.model = model;
            Initialize();
        }

        protected void Initialize()
        {
            view.Report += new EventHandler<EventArgs>(Report);
        }

        private async void RemoveItem()
        {
            await service.Remove(model.Item.Id);
        }

        async void Report(object sender, EventArgs e)
        {
            if (model.Item == null || model.Item.IsReported)
            {
                await DialogAlertManager.ShowInvalidReportDialogAlert(view.Page);
                return;
            }

            if (await DialogAlertManager.ShowReportDialog(view.Page))
            {
                reporter.SendGeneretedMail(model.Item);
                await DialogAlertManager.ShowReportWasSentAlert(view.Page);
            }
        }
       
    }
}
