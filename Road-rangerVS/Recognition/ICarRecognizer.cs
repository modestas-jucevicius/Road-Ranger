using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS
{
    interface ICarRecognizer
    {
        Task<string> Recognize(string imageBase64);
    }
}
