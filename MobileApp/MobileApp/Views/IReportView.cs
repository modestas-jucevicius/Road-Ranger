using System;

namespace MobileApp.Views
{
    public interface IReportView : IBaseView
    {
        string Subject { get; }
        string Body { get; }
        event EventHandler<EventArgs> Report;
    }
}
