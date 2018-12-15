using System;

namespace MobileApp.Views
{
    public interface IMoreView : IBaseView
    {
        event EventHandler<EventArgs> MyGalleryClick;
        event EventHandler<EventArgs> MapClick;
        event EventHandler<EventArgs> StatsClick;
        event EventHandler<EventArgs> ReportClick;
    }
}
