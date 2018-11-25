using System.Drawing;

namespace WindowsFormApp.Views
{
    interface IMainView
    {
        string Path { get; set; }
        Image Frame { get; set; }
    }
}
