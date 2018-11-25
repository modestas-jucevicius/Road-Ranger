using MobileApp.Views;
using MobileApp.Models;
using System;
using Xamarin.Forms;
using MobileApp.Manager;
using System.Collections.Generic;
using Models.Cars;
using Storage.Data;
using System.Linq;

namespace MobileApp.Presenters
{
    public class MyGalleryItemPresenter : BasePresenter
    {
        private IMyGalleryItemView view;
        private Page page;
        private ICarDetailModel model;
        private ReportModel report = new ReportModel();
        private GalleryModel gallery = new GalleryModel();
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
                await DialogAlertManager.GetInstance().ShowInvalidRemoveDialogAlert(page);
                return;
            }

            if (await DialogAlertManager.GetInstance().ShowRemoveDialog(page))
            {
                RemoveItem(); 
                await view.ClosePage();        
            }
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

        private void RemoveItem()
        {
            List<CapturedCar> cars = service.FindAll();
            gallery.RemoveCarById(model.Item.Id);

            if (cars.Where(x => x.Image.Id == model.Item.Image.Id).Count() == 1)
                gallery.RemoveImageById(model.Item.Image.Id); 
        }
    }
}
