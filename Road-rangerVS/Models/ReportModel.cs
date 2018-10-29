
using Road_rangerVS.Recognition;
using Road_rangerVS.Report;
using Road_rangerVS.Cars;

namespace Road_rangerVS.Models
{
	class ReportModel
	{
        private IReportSender sender = new MailReportSender();
		public void SendMail(string subject, string body)
		{
            this.sender.SendMail(subject, body);
        }
        public void SendGeneratedMail(Car car)
        {
            sender.SendGeneretedMail(car);
        }
    }
}
