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
using System.IO;

namespace Road_rangerVS
{
    public partial class FindForm : Form
    {
		private readonly FindPresenter presenter = new FindPresenter();
        private List<CapturedCar> cars = new List<CapturedCar>();
        public FindForm()
        {
            InitializeComponent();
            AddColumns();
        }

        private void AddColumns()
        {
            this.listView.View = View.Details;
            this.listView.Columns.Add("ID", 60, HorizontalAlignment.Left);
            this.listView.Columns.Add("License Plate", 60, HorizontalAlignment.Left);
            this.listView.Columns.Add("Status", 120, HorizontalAlignment.Left);
            this.listView.Columns.Add("Date", 120, HorizontalAlignment.Left);
        }
        private void search_Click(object sender, EventArgs e)
        {
            this.listView.Items.Clear();
            cars = presenter.findByPlate(inputText.Text);
            foreach (CapturedCar car in cars)
            {
                TimeSpan time = TimeSpan.FromMilliseconds(car.image.timestamp * 1000);
                DateTime dateTime = new DateTime(1970, 1, 1) + time;
                //long beginTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
                //DateTime dateTime = new DateTime(beginTicks + car.image.timestamp, DateTimeKind.Utc);

                string[] row = { car.car.id.ToString(), car.car.licensePlate, car.car.status.ToString(), dateTime.ToLocalTime().ToString()};
                var listViewItem = new ListViewItem(row);
                this.listView.Items.Add(listViewItem);
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(listView.SelectedItems[0].SubItems[0].Text);
                CapturedCar capturedCar = cars.First(x => x.car.id == id);
                Console.WriteLine(capturedCar.ToString());

                Bitmap image = new Bitmap(capturedCar.image.path);
                pictureBox.Image = image;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
