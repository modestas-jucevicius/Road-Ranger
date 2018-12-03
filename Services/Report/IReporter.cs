using Models.Cars;
using Models.Messages;

namespace Services.Report
{
    public interface IReporter
    {
        void SendGeneretedMail(Car car);
        void SendMail(Message message);
    }
}
