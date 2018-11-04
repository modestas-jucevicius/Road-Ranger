using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Search;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using Road_rangerVS.Search;
using Road_rangerVS.Recognition;
using Road_rangerVS.Cars;
<<<<<<< HEAD
>>>>>>> 14143fd53e9df87f9d61baa2872c61231ac6452d
=======
>>>>>>> 14143fd53e9df87f9d61baa2872c61231ac6452d

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
