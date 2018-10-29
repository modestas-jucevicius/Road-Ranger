using Road_rangerVS.Recognition;
using System.Collections.Generic;
using Road_rangerVS.Cars;

namespace Road_rangerVS
{
    interface ICarParser
    {
        List<Car> Parse(string result);
    }
}

