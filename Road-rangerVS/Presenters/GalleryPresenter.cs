
using System.Collections.Generic;
using Road_rangerVS.Recognition;
using Road_rangerVS.Models;
using System.Windows.Forms;
using System;
using Road_rangerVS.Views;
using System.Linq;
using Road_rangerVS.OutsideAPI;

namespace Road_rangerVS.Presenters
{
	class GalleryPresenter
	{
		private readonly GalleryModel model = new GalleryModel();
        List<CapturedCar> cars = new List<CapturedCar>();
        int userId;

        public GalleryPresenter(int userId)
        {
            this.userId = userId;
        }

        public List<CapturedCar> GetCarByUserId() {
			return this.model.GetFinder().FindByUserId(userId);
		}

        public void ShowGallery(IGalleryView view)
        {
            cars = GetCarByUserId();
            IsGalleryEmpty(cars);

            foreach (CapturedCar car in cars)
            {
                TimeSpan time = TimeSpan.FromMilliseconds(car.image.timestamp * 1000);
                DateTime dateTime = new DateTime(1970, 1, 1) + time;

                string[] row = { car.id.ToString(), car.licensePlate, car.status.ToString(), dateTime.ToLocalTime().ToString() };
                var listViewItem = new ListViewItem(row);
                view.car = listViewItem;
            }
        }

        private void IsGalleryEmpty(List<CapturedCar> cars)
        {
            if (cars.Count == 0)
            {
                MessageBox.Show(@"Your gallery is empty.", "My Gallery", MessageBoxButtons.OK);
            }
        }

        public void SelectByIndex(IGalleryView view, int id)
        {
            CapturedCar car = cars.FirstOrDefault(x => x.id == id);
            view.image = new System.Drawing.Bitmap(car.image.path);
            EnableReport(view, car);
        }

        private void EnableReport(IGalleryView view, CapturedCar car)
        {
            if (car.status.Equals(CarStatus.STOLEN))
                view.enableReport = true;
            else
                view.enableReport = false;
        }

        public void RemoveByIndex(IGalleryView view, int id)
        {
            CapturedCar car = cars.FirstOrDefault(x => x.id == id);
            this.model.RemoveCarById(car.id);
            this.model.RemoveImageById(car.image.id);
            this.ShowGallery(view);
        }
    }
}
