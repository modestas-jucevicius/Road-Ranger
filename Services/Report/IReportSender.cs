using Models.Cars;

namespace Services.Report
{
    public interface IReportSender
    {
        void SendGeneretedMail(Car car);
        void SendMail(string subject, string body);
    }
}
