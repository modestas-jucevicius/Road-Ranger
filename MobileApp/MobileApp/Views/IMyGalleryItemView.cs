using System;
using System.Threading.Tasks;

namespace MobileApp.Views
{
    public interface IMyGalleryItemView : IReportItemView
    {
        event EventHandler<EventArgs> Remove;
        Task ClosePage();
    }
}
