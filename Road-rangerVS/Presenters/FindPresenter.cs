using System;
using System.Collections.Generic;
using System.Linq;
using Road_rangerVS.Models;
using Road_rangerVS.Views;
using System.Windows.Forms;
<<<<<<< HEAD
<<<<<<< HEAD
using RoadRangerBackEnd.Cars;
=======
using Road_rangerVS.Cars;
>>>>>>> 14143fd53e9df87f9d61baa2872c61231ac6452d
=======
using Road_rangerVS.Cars;
>>>>>>> 14143fd53e9df87f9d61baa2872c61231ac6452d

namespace Road_rangerVS.Presenters
{
	class FindPresenter
	{
		private readonly FindModel model = new FindModel();
        private List<CapturedCar> cars = new List<CapturedCar>();

        private List<CapturedCar> FindByPlate(string licencePlate)
		{
			return this.model.FindByPlate(licencePlate);
		}
        public CapturedCar FindOneById(int id)
        {
            return cars.FirstOrDefault(x => x.Id == id);
        }

        public void SelectByIndex(ISearchView view, int id)
        {
            CapturedCar car = cars.FirstOrDefault(x => x.Id == id);
            view.Image = new System.Drawing.Bitmap(car.Image.Path);
        }

        public void Search(ISearchView view)
        {
            cars = this.FindByPlate(view.LicensePlate);
            foreach (CapturedCar car in cars)
            {
                TimeSpan time = TimeSpan.FromMilliseconds(car.Image.Timestamp * 1000);
                DateTime dateTime = new DateTime(1970, 1, 1) + time;

                string[] row = { car.Id.ToString(), car.LicensePlate, car.Status.ToString(), dateTime.ToLocalTime().ToString() };
                var listViewItem = new ListViewItem(row);
                view.FoundCar = listViewItem;
            }
        }
	}
}
