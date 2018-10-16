using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Search;
using Road_rangerVS.Recognition;

namespace Road_rangerVS.Models
{
	class FindModel
	{
		private readonly ICapturedCarFinder finder = new CapturedCarFinder();

		public List<CapturedCar> findByPlate(string licencePlate)
		{
			return finder.FindByPlate(licencePlate);
		}
	}
}
