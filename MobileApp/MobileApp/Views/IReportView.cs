using System;

namespace MobileApp.Views
{
    public interface IReportView
    {
        string Subject { get; }
        string Body { get; }
        event EventHandler<EventArgs> Report;
    }
}
