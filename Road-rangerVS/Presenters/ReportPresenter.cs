
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

		public void SendMail(IReportView view)
		{
			this.model.SendMail(view.Subject, view.Message);
		}
	}
}
