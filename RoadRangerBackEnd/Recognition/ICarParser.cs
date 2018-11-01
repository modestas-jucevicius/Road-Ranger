using RoadRangerBackEnd.Cars;
using System.Collections.Generic;

namespace RoadRangerBackEnd.Recognition
{
    public interface ICarParser
    {
        List<Car> Parse(string result);
    }
}

