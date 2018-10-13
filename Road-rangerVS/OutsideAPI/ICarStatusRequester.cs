using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.OutsideAPI
{
    interface ICarStatusRequester
    {
        Task<CarStatus> AskCarStatus(string licensePlate);
    }
}
