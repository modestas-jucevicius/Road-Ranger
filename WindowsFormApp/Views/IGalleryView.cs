using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormApp.Views
{
    public interface IGalleryView
    {
        Bitmap Image { get; set; }
        ListViewItem Car { get; set; }
        bool EnableReport { get; set; }
    }
}
