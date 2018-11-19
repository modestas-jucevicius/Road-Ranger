using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Data;
using System.Collections.Generic;

namespace Road_rangerVS.Models
{
	public class FindModel
	{
		private readonly CapturedCarService finder = new CapturedCarService();

		public List<CapturedCar> FindByPlate(string licencePlate)
		{
			return finder.FindByPlate(licencePlate);
		}
	}
}
