using Models.Cars;
using Services.Report;
using System.Threading.Tasks;

namespace MobileApp.Models
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
