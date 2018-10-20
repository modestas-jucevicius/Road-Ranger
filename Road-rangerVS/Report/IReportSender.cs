using Road_rangerVS.Recognition;

namespace Road_rangerVS.Report
{
    interface IReportSender
    {
        void SendGeneretedMail(Car car);
        void SendMail(string subject, string body);
    }
}
