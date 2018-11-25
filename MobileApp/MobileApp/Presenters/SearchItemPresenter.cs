using MobileApp.Views;
using Models.Cars;
using MobileApp.Models;
using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Storage.Data;
using System.Linq;
using MobileApp.Manager;

namespace MobileApp.Presenters
{
    public class SearchItemPresenter
    {
        protected readonly CapturedCarService service = new CapturedCarService();
        protected readonly GalleryModel gallery = new GalleryModel();
        protected readonly ReportModel report = new ReportModel();
        private IReportItemView view;
        private Page page;
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

        private void RemoveItem()
        {
            List<CapturedCar> cars = service.FindAll();
            gallery.RemoveCarById(model.Item.Id);

            if (cars.Where(x => x.Image.Id == model.Item.Image.Id).Count() == 1)
                gallery.RemoveImageById(model.Item.Image.Id);
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
