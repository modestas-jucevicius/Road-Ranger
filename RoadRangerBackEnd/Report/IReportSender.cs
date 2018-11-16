using RoadRangerBackEnd.Cars;
using System.Threading.Tasks;

namespace RoadRangerBackEnd.Report
{
    public interface IReportSender
    {
        void SendGeneretedMail(Car car);
        void SendMail(string subject, string body);
    }
}
