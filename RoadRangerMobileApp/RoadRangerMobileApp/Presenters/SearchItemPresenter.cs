using Road_rangerVS.Models;
using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Search;
using RoadRangerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadRangerMobileApp.Presenters
{
    public class SearchItemPresenter
    {
        protected ICapturedCarFinder finder = new CapturedCarFinder();
        protected readonly GalleryModel galleryModel = new GalleryModel();
        protected readonly ReportModel reportModel = new ReportModel();
        private IReportItemView view;
        protected CarDetailViewModel viewModel;

        public SearchItemPresenter(IReportItemView view, CarDetailViewModel viewModel)
        {
            this.view = view;
            this.viewModel = viewModel;
            this.Initialize();
        }

        protected void Initialize()
        {
            this.view.Report += new EventHandler<EventArgs>(Report);
        }

        private void RemoveItem()
        {
            List<CapturedCar> cars = finder.FindAll();
            galleryModel.RemoveCarById(viewModel.Item.Id);

            if (cars.Where(x => x.Image.Id == viewModel.Item.Image.Id).Count() == 1)
                galleryModel.RemoveImageById(viewModel.Item.Image.Id);
        }

        async void Report(object sender, EventArgs e)
        {
            if (viewModel.Item == null || viewModel.Item.IsReported)
            {
                await view.ShowInvalidReportDialogAlert();
                return;
            }

            if (await view.ShowReportDialog())
            {
                reportModel.SendGeneratedMail(viewModel.Item);
            }
        }
    }
}
