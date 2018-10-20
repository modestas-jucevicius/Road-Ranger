
using System.Threading.Tasks;

namespace Road_rangerVS.OutsideAPI
{
    interface ICarStatusRequester
    {
        Task<CarStatus> AskCarStatus(string licensePlate);
    }
}
