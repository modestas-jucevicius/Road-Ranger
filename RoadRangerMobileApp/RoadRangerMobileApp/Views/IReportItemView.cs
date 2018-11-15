using System;
using System.Threading.Tasks;

namespace RoadRangerMobileApp.Views
{
    public interface IReportItemView
    {
        event EventHandler<EventArgs> Report;
        Task<bool> ShowReportDialog();
        Task ShowInvalidReportDialogAlert();
    }
}
