using Road_rangerVS.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.Search
{
    interface ICapturedCarFinder
    {
        List<CapturedCar> FindByPlate(string licensePlate);
        List<CapturedCar> FindByUserId(int id);
    }
}
