using Road_rangerVS.Recognition;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Road_rangerVS.Views
{
    public interface ISearchView
    {
        string LicensePlate { get; set; }
        Bitmap Image { get; set; }
        ListViewItem FoundCar { get; set; }
    }
}
