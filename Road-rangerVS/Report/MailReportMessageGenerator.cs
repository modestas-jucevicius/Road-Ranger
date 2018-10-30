using Road_rangerVS.Recognition;
using System;
using Road_rangerVS.Cars;

namespace Road_rangerVS.Report
{
    class MailReportMessageGenerator
    {
        public string GenerateMessage(Car car)
        {
            return "Registracijos numeris: " + car.LicensePlate + " , busena: " + car.Status + ", data: " + DateTime.Now;
        }
    }
}
