using Road_rangerVS.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.Report
{
    interface IReportSender
    {
        void SendGeneretedMail(Car car);
        void SendMail(string subject, string body);
    }
}
