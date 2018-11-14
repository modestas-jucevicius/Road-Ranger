using System;
using System.Threading.Tasks;

namespace RoadRangerMobileApp.Views
{
    public interface IMyGalleryItemView : IReportItemView
    {
        event EventHandler<EventArgs> Remove;
        Task<bool> ShowRemoveDialog();
        Task ShowInvalidRemoveDialogAlert();
        Task ClosePage();
    }
}
