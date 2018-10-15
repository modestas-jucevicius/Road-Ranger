using Road_rangerVS.Recognition;
using Road_rangerVS.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Road_rangerVS.Presenters;

namespace Road_rangerVS
{
    public partial class HistoryForm : Form
    {
    private HistoryPresenter presenter;
    public HistoryForm()
    {
        InitializeComponent();
        presenter = new HistoryPresenter();
    }

        private void history_Click(object sender, EventArgs e)
        {
            int userId = 0;

            ICapturedCarFinder finder = new CapturedCarFinder();
            List<CapturedCar> cars = finder.FindByUserId(userId);
            Console.WriteLine(cars.ToString());

            result.Text = cars.ToString();
        }
    }
}
