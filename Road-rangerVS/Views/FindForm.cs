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
    public partial class FindForm : Form
    {
		private readonly FindPresenter presenter = new FindPresenter();
        public FindForm()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {   
			List<CapturedCar> cars = presenter.findByPlate(inputText.Text);
            string text = "";
            foreach (CapturedCar car in cars)
            {
                Console.WriteLine(car.ToString());
                text += car.ToString();
            }
			
			result.Text = text;
        }
    }
}
