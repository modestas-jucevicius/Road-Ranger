using Road_rangerVS.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoadRangerMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportPage : ContentPage
	{
        private ReportModel reportModel;
		public ReportPage ()
		{
			InitializeComponent ();
            reportModel = new ReportModel();
		}

        private async void Send_Button(object sender, EventArgs e)
        {
            string subject = Subject.Text;
            string body = Body.Text;
            try
            {
                await reportModel.SendMail(subject, body);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Report", "Because of internal issues you can not report. Please try again!", "OK");
            }
        }
    }
}