using RoadRangerBackEnd.Cars;
using System;
using Road_rangerVS.Cars;

namespace RoadRangerBackEnd.Report
{
    public class MailReportMessageGenerator
    {
        public string GenerateMessage(Car car)
        {
            return "Registracijos numeris: " + car.LicensePlate + " , busena: " + car.Status + ", data: " + DateTime.Now;
        }
    }
}
