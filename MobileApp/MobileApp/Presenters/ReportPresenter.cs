using MobileApp.Manager;
using MobileApp.Models;
using MobileApp.Views;
using System;
using Xamarin.Forms;

namespace MobileApp.Presenters
{
    public class ReportPresenter
    {
        private readonly IReportView view;
        private Page page;
        private static ReportPresenter presenter = null;
        private ReportModel report = new ReportModel();

        public static ReportPresenter GetInstance(ReportPage page)
        {
            if (presenter == null)
            {
                presenter = new ReportPresenter(page);
            }
            return presenter;
        }

        private ReportPresenter()
        {
        }

        private ReportPresenter(ReportPage page)
        {
            this.page = page;
            this.view = page;
            this.Initialize();
        }

        public void Initialize()
        {
            this.view.Report += new EventHandler<EventArgs>(Report);
        }

        public async void Report(object sender, EventArgs e)
        {
            string subject = view.Subject;
            string body = view.Body;
            try
            {
                await report.SendMail(subject, body);
            }
            catch (Exception ex)
            {
                await DialogAlertManager.GetInstance().ShowReportSendAlert(page);
            }
        }
    }
}
