using System;
using System.Collections.Generic;
using System.Linq;
using Road_rangerVS.Models;
using Road_rangerVS.Recognition;
using Road_rangerVS.Views;
using System.Windows.Forms;

namespace Road_rangerVS.Presenters
{
	class FindPresenter
	{
		private readonly FindModel model = new FindModel();
        private List<CapturedCar> cars = new List<CapturedCar>();

        private List<CapturedCar> findByPlate(string licencePlate)
		{
			return this.model.findByPlate(licencePlate);
		}
        public CapturedCar findOneById(int id)
        {
            return cars.FirstOrDefault(x => x.id == id);
        }

        public void SelectByIndex(ISearchView view, int id)
        {
            CapturedCar car = cars.FirstOrDefault(x => x.id == id);
            view.image = new System.Drawing.Bitmap(car.image.path);
        }

        public void Search(ISearchView view)
        {
            cars = findByPlate(view.licensePlate);
            foreach (CapturedCar car in cars)
            {
                TimeSpan time = TimeSpan.FromMilliseconds(car.image.timestamp * 1000);
                DateTime dateTime = new DateTime(1970, 1, 1) + time;

                string[] row = { car.id.ToString(), car.licensePlate, car.status.ToString(), dateTime.ToLocalTime().ToString() };
                var listViewItem = new ListViewItem(row);
                view.foundCar = listViewItem;
            }
        }
	}
}
