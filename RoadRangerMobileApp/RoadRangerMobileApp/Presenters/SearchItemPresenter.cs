using Road_rangerVS.Models;
using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Search;
using RoadRangerMobileApp.Models;
using RoadRangerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadRangerMobileApp.Presenters
{
    public class SearchItemPresenter
    {
        protected readonly ICapturedCarFinder finder = new CapturedCarFinder();
        protected readonly GalleryModel galleryModel = new GalleryModel();
        protected readonly ReportModel reportModel = new ReportModel();
        private IReportItemView view;
        protected ICarDetailModel model;

        public SearchItemPresenter(IReportItemView view, ICarDetailModel model)
        {
            this.view = view;
            this.model = model;
            this.Initialize();
        }

        public SearchItemPresenter()
        {
            this.Initialize();
        }

        protected void Initialize()
        {
            this.view.Report += new EventHandler<EventArgs>(Report);
        }

        private void RemoveItem()
        {
            List<CapturedCar> cars = finder.FindAll();
            galleryModel.RemoveCarById(model.Item.Id);

            if (cars.Where(x => x.Image.Id == model.Item.Image.Id).Count() == 1)
                galleryModel.RemoveImageById(model.Item.Image.Id);
        }

        async void Report(object sender, EventArgs e)
        {
            if (model.Item == null || model.Item.IsReported)
            {
                await view.ShowInvalidReportDialogAlert();
                return;
            }

            if (await view.ShowReportDialog())
            {
                reportModel.SendGeneratedMail(model.Item);
            }
        }
    }
}
