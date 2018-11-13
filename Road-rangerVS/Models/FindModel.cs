using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Search;
using System.Collections.Generic;
using RoadRangerBackEnd.Recognition;

namespace Road_rangerVS.Models
{
	class FindModel
	{
		private readonly ICapturedCarFinder finder = new CapturedCarFinder();

		public List<CapturedCar> FindByPlate(string licencePlate)
		{
			return finder.FindByPlate(licencePlate);
		}
	}
}
