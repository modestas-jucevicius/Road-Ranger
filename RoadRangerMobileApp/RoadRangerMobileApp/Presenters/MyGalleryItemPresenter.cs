using RoadRangerBackEnd.Cars;
using RoadRangerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadRangerMobileApp.Presenters
{
    public class MyGalleryItemPresenter : SearchItemPresenter
    {
        private IMyGalleryItemView view;
        
        public MyGalleryItemPresenter(IMyGalleryItemView view, CarDetailViewModel viewModel) : base(view, viewModel)
        {
            this.view = view;
            base.viewModel = viewModel;
            this.Initialize();
        }

        protected void Initialize()
        {
            base.Initialize();
            this.view.Remove += new EventHandler<EventArgs>(Remove);
        }

        async void Remove(object sender, EventArgs e)
        {
            if (viewModel.Item == null)
            {
                await view.ShowInvalidRemoveDialogAlert();
                return;
            }

            if (await view.ShowRemoveDialog())
            {
                RemoveItem(); 
                await view.ClosePage();        
            }
        }

        private void RemoveItem()
        {
            List<CapturedCar> cars = finder.FindAll();
            galleryModel.RemoveCarById(viewModel.Item.Id);

            if (cars.Where(x => x.Image.Id == viewModel.Item.Image.Id).Count() == 1)
                galleryModel.RemoveImageById(viewModel.Item.Image.Id); 
        }

    }
}
