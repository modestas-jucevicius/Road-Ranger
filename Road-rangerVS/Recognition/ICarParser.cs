using Road_rangerVS.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS
{
    interface ICarParser
    {
        List<Car> Parse(string result);
    }
}

