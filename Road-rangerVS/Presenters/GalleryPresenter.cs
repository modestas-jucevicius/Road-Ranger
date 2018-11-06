using System.Collections.Generic;
using Road_rangerVS.Models;
using System.Windows.Forms;
using System;
using Road_rangerVS.Views;
using System.Linq;
using RoadRangerBackEnd.Cars;

namespace Road_rangerVS.Presenters
{
	class GalleryPresenter
	{
		private readonly GalleryModel galleryModel = new GalleryModel();
        private readonly ReportModel reportModel = new ReportModel();
        List<CapturedCar> cars = new List<CapturedCar>();
		readonly int userId;

        public GalleryPresenter(int userId)
        {
            this.userId = userId;
        }

        public List<CapturedCar> GetCarByUserId()
        {
			return this.galleryModel.GetFinder().FindByUserId(userId);
		}

        public void ShowGallery(IGalleryView view)
        {
            cars = GetCarByUserId();
            IsGalleryEmpty(cars);

            foreach (CapturedCar car in cars)
            {
                TimeSpan time = TimeSpan.FromMilliseconds(car.Image.Timestamp * 1000);
                DateTime dateTime = new DateTime(1970, 1, 1) + time;

                string[] row = { car.Id.ToString(), car.LicensePlate, car.Status.ToString(), dateTime.ToLocalTime().ToString() };
                var listViewItem = new ListViewItem(row);
                view.Car = listViewItem;
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
            CapturedCar car = cars.FirstOrDefault(x => x.Id == id);
            view.Image = new System.Drawing.Bitmap(car.Image.Path);
            EnableReport(view, car);
        }

        private void EnableReport(IGalleryView view, CapturedCar car)
        {
            if (car.Status.Equals(CarStatus.STOLEN) && !car.IsReported)
                view.EnableReport = true;
            else
                view.EnableReport = false;
        }

        public void RemoveByIndex(IGalleryView view, int id)
        {
            CapturedCar car = cars.FirstOrDefault(x => x.Id == id);
            this.galleryModel.RemoveCarById(car.Id);
            this.galleryModel.RemoveImageById(car.Image.Id);
            this.ShowGallery(view);
        }

        public void ReportByIndex(IGalleryView view, int id)
        {
            CapturedCar car = cars.FirstOrDefault(x => x.Id == id);
            reportModel.SendGeneratedMail(car);
        }
    }
}
