using System;

namespace MobileApp.Views
{
    public interface IReportItemView : IBaseView
    {
        event EventHandler<EventArgs> Report;
    }
}
