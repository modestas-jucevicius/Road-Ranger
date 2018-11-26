using MobileApp.Views;
using MobileApp.Models;
using System;
using Xamarin.Forms;
using MobileApp.Manager;
using WebService.WebService;

namespace MobileApp.Presenters
{
    public class SearchItemPresenter
    {
        protected readonly CapturedCarService service = new CapturedCarService();
        protected readonly ReportModel report = new ReportModel();
        private IReportItemView view;
        private readonly Page page;
        private ICarDetailModel model;

        public SearchItemPresenter(SearchItemPage page, ICarDetailModel model)
        {
            this.page = page;
            view = page;
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
                await DialogAlertManager.GetInstance().ShowInvalidReportDialogAlert(page);
                return;
            }

            if (await DialogAlertManager.GetInstance().ShowReportDialog(page))
            {
                await report.SendGeneratedMail(model.Item);
            }
        }
       
    }
}
