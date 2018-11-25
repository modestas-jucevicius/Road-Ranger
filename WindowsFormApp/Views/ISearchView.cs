using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormApp.Views
{
    public interface ISearchView
    {
        string LicensePlate { get; set; }
        Bitmap Image { get; set; }
        ListViewItem FoundCar { get; set; }
    }
}
