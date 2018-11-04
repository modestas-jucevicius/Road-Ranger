using RoadRangerBackEnd.Cars;
using System.Collections.Generic;
using Road_rangerVS.Cars;

namespace RoadRangerBackEnd.Search
{
    public interface ICapturedCarFinder
    {
        List<CapturedCar> FindByPlate(string licensePlate);
        List<CapturedCar> FindByUserId(int id);
        List<CapturedCar> FindAll();
    }
}
