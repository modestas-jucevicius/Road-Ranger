
using Road_rangerVS.Models;

namespace Road_rangerVS.Presenters
{
	class ReportPresenter
	{
		private ReportModel model;

		public ReportPresenter()
		{
			model = new ReportModel();
		}

		public void sendMail(string recipient, string subject, string body)
		{
			this.model.SendMail(recipient, subject, body);
		}
	}
}
