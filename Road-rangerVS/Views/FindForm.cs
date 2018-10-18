
using System;
using System.Drawing;
using System.Windows.Forms;
using Road_rangerVS.Presenters;
using Road_rangerVS.OutsideAPI;
using Road_rangerVS.Validation;
using Road_rangerVS.Views;

namespace Road_rangerVS
{
    public partial class FindForm : Form, ISearchView
    {
		private readonly FindPresenter presenter = new FindPresenter();
        string ISearchView.licensePlate {
            get
            {
                return inputText.Text;
            }
            set
            {
                inputText.Text = value;
            }
        }

        public Bitmap image
        {
            get
            {
                return new Bitmap(pictureBox.Image);
            }
            set
            {
                pictureBox.Image = value;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        public ListViewItem foundCar
        {
            get
            {
                return new ListViewItem();
            }
            set
            {
                this.listView.Items.Add(value);
            }
        }

        public FindForm()
        {
            InitializeComponent();
            AddColumns();
        }

        private void AddColumns()
        {
            this.listView.View = View.Details;
            this.listView.Columns.Add("ID", 30, HorizontalAlignment.Left);
            this.listView.Columns.Add("License Plate", 60, HorizontalAlignment.Left);
            this.listView.Columns.Add("Status", 120, HorizontalAlignment.Left);
            this.listView.Columns.Add("Date", 120, HorizontalAlignment.Left);
        }
        private void SearchClick(object sender, EventArgs e)
        {
            TextValidator validator = new LicensePlateValidator();
            if (validator.isValid(inputText.Text))
            {
                this.listView.Items.Clear();
                presenter.Search(this);
            }
            else
            {
                MessageBox.Show("Car license plate is not valid! License plate should be AAA000 or AA000 format.");
            }
        }

        private void ListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(listView.SelectedItems[0].SubItems[0].Text);
                this.presenter.SelectByIndex(this, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
