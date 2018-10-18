using Road_rangerVS.Recognition;
using System.Collections.Generic;

namespace Road_rangerVS
{
    interface ICarParser
    {
        List<Car> Parse(string result);
    }
}

