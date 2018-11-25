using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportPage : ContentPage, IReportView
    {
        public ReportPage ()
		{
			InitializeComponent ();
		}

        private void Send_Button(object sender, EventArgs args)
        {
            if (this.Report != null)
                Report(this, args);
        }

        string IReportView.Subject => Subject.Text;

        string IReportView.Body => Body.Text;

        public event EventHandler<EventArgs> Report;
    }
}