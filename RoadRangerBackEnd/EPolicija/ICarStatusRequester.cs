using RoadRangerBackEnd.Cars;
using System.Threading.Tasks;

namespace RoadRangerBackEnd.OutsideAPI
{
    public interface ICarStatusRequester
    {
        Task<CarStatus> AskCarStatus(string licensePlate);
    }
}
