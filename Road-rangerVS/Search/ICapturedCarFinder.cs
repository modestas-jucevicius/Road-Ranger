using Road_rangerVS.Recognition;
using System.Collections.Generic;
using Road_rangerVS.Cars;

namespace Road_rangerVS.Search
{
    interface ICapturedCarFinder
    {
        List<CapturedCar> FindByPlate(string licensePlate);
        List<CapturedCar> FindByUserId(int id);
    }
}
