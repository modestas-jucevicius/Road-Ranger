using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Search;
using Road_rangerVS.Recognition;
using Road_rangerVS.Models;

namespace Road_rangerVS.Presenters
{
	class HistoryPresenter
	{
		private readonly HistoryModel model = new HistoryModel();

		public List<CapturedCar> getCars(int userId) {
			return this.model.getFinder().FindByUserId(userId);
		}
	}
}
