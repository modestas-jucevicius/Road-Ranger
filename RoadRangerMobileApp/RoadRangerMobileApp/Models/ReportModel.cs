
using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Report;
using System.Threading.Tasks;

namespace Road_rangerVS.Models
{
	public class ReportModel
	{
        private IReportSender sender = new MailReportSender();
		public async Task SendMail(string subject, string body)
		{
            this.sender.SendMail(subject, body);
        }
        public async Task SendGeneratedMail(Car car)
        {
            sender.SendGeneretedMail(car);
        }
    }
}
