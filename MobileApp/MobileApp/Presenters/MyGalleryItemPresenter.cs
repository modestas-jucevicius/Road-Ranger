using MobileApp.Views;
using MobileApp.Models;
using System;
using MobileApp.Manager;
using MobileApp.Services.WebAPI.Cars;
using MobileApp.Services.Report;

namespace MobileApp.Presenters
{
    public class MyGalleryItemPresenter : BasePresenter
    {
        private IMyGalleryItemView view;
        private ICarDetailModel model;
        private IReporter reporter = new MailReporter();
        private CapturedCarService service = new CapturedCarService();

        public MyGalleryItemPresenter(IMyGalleryItemView view, ICarDetailModel model)
        {
            this.view = view;
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
                await DialogAlertManager.ShowInvalidRemoveDialogAlert(view.Page);
                return;
            }

            if (await DialogAlertManager.ShowRemoveDialog(view.Page))
            {
                RemoveItem(); 
                await view.ClosePage();        
            }
        }

        async void Report(object sender, EventArgs e)
        {
            view.IsPressable = false;
            if (model.Item == null || model.Item.IsReported)
            {
                await DialogAlertManager.ShowInvalidReportDialogAlert(view.Page);
                return;
            }

            if (await DialogAlertManager.ShowReportDialog(view.Page))
            {
                reporter.SendGeneretedMail(model.Item);
            }
            view.IsPressable = true;
        }

        private async void RemoveItem()
        {
            view.IsPressable = false;
            await service.Remove(model.Item.Id);
            await DialogAlertManager.ShowReportWasSentAlert(view.Page);
            view.IsPressable = true;
        }
    }
}
