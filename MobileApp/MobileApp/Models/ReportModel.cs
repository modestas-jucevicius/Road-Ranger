using Models.Cars;
using Models.Messages;
using MobileApp.Services.Report;
using System.Threading.Tasks;

namespace MobileApp.Models
{
	public class ReportModel
	{
        private IReporter sender = new MailReporter();
		public async Task SendMail(Message message)
		{
            this.sender.SendMail(message);
        }
        public async Task SendGeneratedMail(Car car)
        {
            sender.SendGeneretedMail(car);
        }
    }
}
