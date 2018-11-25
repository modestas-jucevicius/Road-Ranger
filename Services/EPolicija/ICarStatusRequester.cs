using Models.Cars;
using System.Threading.Tasks;

namespace Services.EPolicija
{
    public interface ICarStatusRequester
    {
        Task<CarStatus> AskCarStatus(string licensePlate);
    }
}
