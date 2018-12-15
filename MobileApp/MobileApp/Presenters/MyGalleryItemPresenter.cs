using MobileApp.Views;
using System;
using MobileApp.Manager;
using MobileApp.Services.WebAPI.Cars;
using MobileApp.Services.Report;
using Models.Cars;

namespace MobileApp.Presenters
{
    public class MyGalleryItemPresenter : BasePresenter
    {
        private IMyGalleryItemView view;
        public CapturedCar Item { get; set; }
        private IReporter reporter = new MailReporter();
        private CapturedCarService service = new CapturedCarService();

        public MyGalleryItemPresenter(IMyGalleryItemView view, CapturedCar car)
        {
            this.view = view;
            Item = car;
            Initialize();
        }

        protected void Initialize()
        {
            view.Report += new EventHandler<EventArgs>(Report);
            view.Remove += new EventHandler<EventArgs>(Remove);
        }

        async void Remove(object sender, EventArgs e)
        {
            if (Item == null)
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
            if (Item == null || Item.IsReported)
            {
                await DialogAlertManager.ShowInvalidReportDialogAlert(view.Page);
                return;
            }

            if (await DialogAlertManager.ShowReportDialog(view.Page))
            {
                reporter.SendGeneretedMail(Item);
            }
            view.IsPressable = true;
        }

        private async void RemoveItem()
        {
            view.IsPressable = false;
            await service.Remove(Item.Id);
            await DialogAlertManager.ShowReportWasSentAlert(view.Page);
            view.IsPressable = true;
        }
    }
}
