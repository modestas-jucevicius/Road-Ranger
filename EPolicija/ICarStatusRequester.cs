using Models.Cars;
using System.Threading.Tasks;

namespace EPolicija
{
    public interface ICarStatusRequester
    {
        Task<CarStatus> AskCarStatus(string licensePlate);
    }
}
