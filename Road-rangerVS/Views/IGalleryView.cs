using System.Drawing;
using System.Windows.Forms;

namespace Road_rangerVS.Views
{
    public interface IGalleryView
    {
        Bitmap Image { get; set; }
        ListViewItem Car { get; set; }
        bool EnableReport { get; set; }
    }
}
