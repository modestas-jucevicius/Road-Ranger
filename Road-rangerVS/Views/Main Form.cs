using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Road_rangerVS.Data;
using Road_rangerVS.OutsideAPI;
using Road_rangerVS.Recognition;
using Road_rangerVS.Search;
using Road_rangerVS.Presenters;

using AForge.Video;
using AForge.Video.DirectShow;

namespace Road_rangerVS
{
	public partial class MainForm : Form
	{
		private readonly string PATH = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Pictures\\";     // ~/bin/Debug/Pictures/
		private MainPresenter presenter;

		public MainForm()
		{
			InitializeComponent();
			presenter = new MainPresenter();
        }

		private void label1_Click(object sender, EventArgs e)
		{

		}

        private async void uploadButtonClick(object sender, EventArgs e)
        {
			if (!File.Exists(filePath.Text))
			{
				MessageBox.Show("Wrong Image Path!");
			}
			else
			{
				try
				{
					await presenter.getCarInfo(filePath.Text);
				}
				catch (ParseException exception)
				{
					MessageBox.Show(exception.Message);
				}
			}
        }

        private void browseButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg"; // failo tipai, kurie bus naudojami
            dialog.Multiselect = false; // true - galima pridėti daugiau negu viena failą, false - galima pridėti tik 1 failą
            if (dialog.ShowDialog() == DialogResult.OK) // jei vartotojas paspaudžia OK
            {
                String path = dialog.FileName; // gauna failo vardą
                filePath.Text = path;           // laukui filePath priskiriama path reikšmė
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void mainFormLoading(object sender, EventArgs e)
        {
			comboBox1.Items.AddRange(presenter.loadDevices().ToArray());
			comboBox1.SelectedIndex = 0; // By default pasirinktas bus pirmas objektas comboBox'e
		}

        private void selectCamera(object sender, EventArgs e)
        {

        }

        private void cameraClick(object sender, EventArgs e)
        {
			presenter.CameraClick(comboBox1.SelectedIndex, newFrame);
		}

		private void newFrame(object sender, NewFrameEventArgs eventArgs)
		{
			Bitmap video = (Bitmap)eventArgs.Frame.Clone();     //Sukuriame kadro bitmap'ą
			pictureBox.Image = video;                          //Ir jį ištransliuojame picturBox elemente
		}

		private void captureClick(object sender, EventArgs e)
        {
            pictureBox.Image.Save(PATH + "IMG" + DateTime.Now.ToString("hhmmss") + ".jpg", ImageFormat.Jpeg);

        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
			presenter.closeForm(); //Išjungus programą išsijungs ir kamera.
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void findYourCarButton_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm();
            findForm.ShowDialog();
        }

        private void myHistory_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();
            historyForm.ShowDialog();
        }
    }
}
