using Microcharts;
using System;

namespace RoadRangerMobileApp.Views
{
    public interface IStatisticView
    {
        Chart Chart1 { set; }
        Chart Chart2 { set; }
        Chart Chart3 { set; }
        Chart Chart4 { set; }
        Chart Chart5 { set; }
        event EventHandler<EventArgs> ChartView;
    }
}
