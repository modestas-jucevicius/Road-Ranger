
using System.Threading.Tasks;
using Road_rangerVS.Cars;

namespace Road_rangerVS.EPolicija
{
    interface ICarStatusRequester
    {
        Task<CarStatus> AskCarStatus(string licensePlate);
    }
}
