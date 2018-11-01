using RoadRangerBackEnd.Cars;

namespace RoadRangerBackEnd.Report
{
    public interface IReportSender
    {
        void SendGeneretedMail(Car car);
        void SendMail(string subject, string body);
    }
}
