using Road_rangerVS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private void Send_Button(object sender, EventArgs e)
        {
            string subject = Subject.Text;
            string body = Body.Text;
            reportModel.SendMail(subject, body);
        }
    }
}