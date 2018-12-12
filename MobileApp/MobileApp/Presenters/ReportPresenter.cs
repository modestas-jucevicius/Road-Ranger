using MobileApp.Manager;
using MobileApp.Services.Report;
using MobileApp.Views;
using Models.Messages;
using System;

namespace MobileApp.Presenters
{
    public class ReportPresenter
    {
        private readonly IReportView view;
        private IReporter reporter;

        public ReportPresenter(IReportView view)
        {
            this.view = view;
            reporter = new MailReporter();
            Initialize();
        }

        public void Initialize()
        {
            view.Report += new EventHandler<EventArgs>(Report);
        }

        public async void Report(object sender, EventArgs e)
        {
            view.IsPressable = false;
            if (!string.IsNullOrWhiteSpace(view.Subject) && !string.IsNullOrWhiteSpace(view.Body))
            {
                try
                {
                    reporter.SendMail(new Message
                    {
                        Subject = view.Subject,
                        Body = view.Body
                    });
                    await DialogAlertManager.ShowReportWasSentAlert(view.Page);
                }
                catch (Exception)
                {
                    await DialogAlertManager.ShowReportSendAlert(view.Page);
                }
            }
            else
                await DialogAlertManager.ShowReportValidation(view.Page);
            view.IsPressable = true;
        }
    }
}
