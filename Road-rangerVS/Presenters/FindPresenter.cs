using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Models;
using Road_rangerVS.Search;
using Road_rangerVS.Recognition;

namespace Road_rangerVS.Presenters
{
	class FindPresenter
	{
		private readonly FindModel model = new FindModel();

		public List<CapturedCar> findByPlate(string licencePlate)
		{
			return this.model.findByPlate(licencePlate);
		}

	}
}
