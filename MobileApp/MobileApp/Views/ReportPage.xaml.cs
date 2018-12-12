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
            Report(this, args);
        }

        string IReportView.Subject => Subject.Text;

        string IReportView.Body => Body.Text;

        public bool IsPressable
        {
            set => this.IsEnabled = value;
        }

        public Page Page => this;

        public event EventHandler<EventArgs> Report;
    }
}