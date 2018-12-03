using Models.Cars;
using System;

namespace Services.Report
{
    public class MailMessageGenerator
    {
        public string GenerateMessage(Car car)
        {
            return "Registracijos numeris: " + car.LicensePlate + " , busena: " + car.Status + ", data: " + DateTime.Now;
        }
    }
}
