using Microcharts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StatisticPage : ContentPage, IStatisticView
    {
        public StatisticPage ()
		{
			InitializeComponent ();
        }

        public bool IsPressable
        {
            set => this.IsEnabled = value;
        }

        public Page Page => this;

        public Chart Chart1 { set => chartViewDate.Chart = value; }
        public Chart Chart2 { set => chartViewYear.Chart = value; }
        public Chart Chart3 { set => chartViewLocation.Chart = value; }
        public Chart Chart4 { set => chartViewModel.Chart = value; }
        public Chart Chart5 { set => chartViewStatus.Chart = value; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ChartView(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> ChartView;
    }
}