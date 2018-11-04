
<<<<<<< HEAD
using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Report;
=======
using Road_rangerVS.Recognition;
using Road_rangerVS.Report;
using Road_rangerVS.Cars;
>>>>>>> 14143fd53e9df87f9d61baa2872c61231ac6452d

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
