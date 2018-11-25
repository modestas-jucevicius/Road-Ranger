using Models.Cars;
using System.Collections.Generic;

namespace Services.Recognition
{
    public interface ICarParser
    {
        List<Car> Parse(string result);
    }
}

