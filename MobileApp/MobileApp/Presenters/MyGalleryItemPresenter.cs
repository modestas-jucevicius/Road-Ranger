using MobileApp.Views;
using MobileApp.Models;
using System;
using Xamarin.Forms;
using MobileApp.Manager;
using MobileApp.Services.WebAPI.Cars;

namespace MobileApp.Presenters
{
    public class MyGalleryItemPresenter : BasePresenter
    {
        private IMyGalleryItemView view;
        private readonly Page page;
        private ICarDetailModel model;
        private ReportModel report = new ReportModel();
        private CapturedCarService service = new CapturedCarService();

        public MyGalleryItemPresenter(MyGalleryItemPage page, ICarDetailModel model)
        {
            this.page = page;
            view = page;
            this.model = model;
            Initialize();
        }

        protected void Initialize()
        {
            view.Report += new EventHandler<EventArgs>(Report);
            view.Remove += new EventHandler<EventArgs>(Remove);
        }

        async void Remove(object sender, EventArgs e)
        {
            if (model.Item == null)
            {
                await DialogAlertManager.ShowInvalidRemoveDialogAlert(page);
                return;
            }

            if (await DialogAlertManager.ShowRemoveDialog(page))
            {
                RemoveItem(); 
                await view.ClosePage();        
            }
        }

        async void Report(object sender, EventArgs e)
        {
            if (model.Item == null || model.Item.IsReported)
            {
                await DialogAlertManager.ShowInvalidReportDialogAlert(page);
                return;
            }

            if (await DialogAlertManager.ShowReportDialog(page))
            {
                await report.SendGeneratedMail(model.Item);
            }
        }

        private async void RemoveItem()
        {
            await service.Remove(model.Item.Id);
        }
    }
}
