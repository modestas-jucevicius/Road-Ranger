using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
