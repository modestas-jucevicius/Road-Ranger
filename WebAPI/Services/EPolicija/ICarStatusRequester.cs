using Models.Cars;
using System.Threading.Tasks;

namespace WebAPI.Services.EPolicija
{
    public interface ICarStatusRequester
    {
        Task<CarStatus> AskCarStatus(string licensePlate);
    }
}
