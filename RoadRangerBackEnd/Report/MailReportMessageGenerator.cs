using RoadRangerBackEnd.Cars;
using System;

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
