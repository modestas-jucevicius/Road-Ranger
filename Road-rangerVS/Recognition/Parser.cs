using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS
{
    interface Parser
    {
        List<ParsedCar> Parse(string result);
        bool IsError(string data);
    }
}
