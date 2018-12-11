using Models.Cars;
using System.Collections.Generic;

namespace MobileApp.Services.Recognition
{
    public interface ICarParser
    {
        List<Car> Parse(string result);
    }
}

