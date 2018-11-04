using Road_rangerVS.Recognition;
using Road_rangerVS.Cars;

namespace Road_rangerVS.Report
{
    interface IReportSender
    {
        void SendGeneretedMail(Car car);
        void SendMail(string subject, string body);
    }
}
