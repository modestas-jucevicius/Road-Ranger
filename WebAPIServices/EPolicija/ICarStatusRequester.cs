using Models.Cars;
using System.Threading.Tasks;

namespace WebAPIService.EPolicija
{
    public interface ICarStatusRequester
    {
        Task<CarStatus> AskCarStatus(string licensePlate);
    }
}
