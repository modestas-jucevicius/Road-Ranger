using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Road_rangerVS.Presenters;
using Road_rangerVS.Views;

namespace Road_rangerVS
{
    public partial class GalleryForm : Form, IGalleryView
    {
        private GalleryPresenter presenter;
        private int userId = 0;
        public GalleryForm()
        {
            InitializeComponent();
            AddColumns();
            presenter = new GalleryPresenter(userId);
            ShowGallery();
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

        public ListViewItem car {
            get
            {
                return new ListViewItem();
            }
            set
            {
                this.listView.Items.Add(value);
            }
        }

        public bool enableReport {
            get
            {
                return reportButton.Enabled;
            }
            set
            {
                reportButton.Enabled = value;
            }
        }

        private void AddColumns()
        {
            this.listView.View = View.Details;
            this.listView.Columns.Add("ID", 30, HorizontalAlignment.Left);
            this.listView.Columns.Add("License Plate", 60, HorizontalAlignment.Left);
            this.listView.Columns.Add("Status", 120, HorizontalAlignment.Left);
            this.listView.Columns.Add("Date", 120, HorizontalAlignment.Left);
        }

        private void ShowGallery()
        {
            this.presenter.ShowGallery(this);
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

        private void ReportButtonClick(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(listView.SelectedItems[0].SubItems[0].Text);
                ShowReportMessage(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowReportMessage(int id)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to report car?", "Report message", MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.Yes))
            {
                this.presenter.ReportByIndex(this, id);
            }
        }

        private void ShowRemoveMessage(int id)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove car?", "Remove message", MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.Yes))
            {
                this.listView.Items.Clear();
                this.presenter.RemoveByIndex(this, id);
            }
        }

        private void RemoveButtonClick(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(listView.SelectedItems[0].SubItems[0].Text);
                this.ShowRemoveMessage(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
