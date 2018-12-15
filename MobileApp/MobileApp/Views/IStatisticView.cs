using Microcharts;
using System;

namespace MobileApp.Views
{
    public interface IStatisticView : IBaseView
    {
        Chart Chart1 { set; }
        Chart Chart2 { set; }
        Chart Chart3 { set; }
        Chart Chart4 { set; }
        Chart Chart5 { set; }
        event EventHandler<EventArgs> ChartView;
    }
}
