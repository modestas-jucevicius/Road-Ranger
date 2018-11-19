using RoadRangerBackEnd.Cars;
using RoadRangerMobileApp.Models;
using RoadRangerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadRangerMobileApp.Presenters
{
    public class MyGalleryItemPresenter : SearchItemPresenter
    {
        private IMyGalleryItemView view;
        
        public MyGalleryItemPresenter(IMyGalleryItemView view, ICarDetailModel model) : base(view, model)
        {
            this.view = view;
            base.model = model;
            this.Initialize();
        }

        protected void Initialize()
        {
            base.Initialize();
            this.view.Remove += new EventHandler<EventArgs>(Remove);
        }

        async void Remove(object sender, EventArgs e)
        {
            if (model.Item == null)
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
            List<CapturedCar> cars = service.FindAll();
            galleryModel.RemoveCarById(model.Item.Id);

            if (cars.Where(x => x.Image.Id == model.Item.Image.Id).Count() == 1)
                galleryModel.RemoveImageById(model.Item.Image.Id); 
        }

    }
}
