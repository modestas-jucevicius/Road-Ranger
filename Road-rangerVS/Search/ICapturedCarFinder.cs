using Road_rangerVS.Recognition;
using System.Collections.Generic;

namespace Road_rangerVS.Search
{
    interface ICapturedCarFinder
    {
        List<CapturedCar> FindByPlate(string licensePlate);
        List<CapturedCar> FindByUserId(int id);
    }
}
