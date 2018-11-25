using System;

namespace MobileApp.Views
{
    public interface IReportItemView
    {
        event EventHandler<EventArgs> Report;
    }
}
