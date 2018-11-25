using Models.Cars;
using System.Collections.Generic;

namespace Services.Statistic
{
    public interface IChart
    {
        Microcharts.Chart Get(List<CapturedCar> cars);
    }
}
