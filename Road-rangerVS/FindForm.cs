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

namespace Road_rangerVS
{
    public partial class FindForm : Form
    {
        public FindForm()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            string licensePlate = inputText.Text;

            ICapturedCarFinder finder = new CapturedCarFinder();
            List<CapturedCar> cars = finder.FindByPlate(licensePlate);
            Console.WriteLine(cars.ToString());

            result.Text = cars.ToString();
        }
    }
}
