using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Road_rangerVS.Recognition;
using Road_rangerVS.Presenters;
using AForge.Video;

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

        private async void UploadButtonClick(object sender, EventArgs e)
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

        private void BrowseButtonClick(object sender, EventArgs e)
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

        private void MainFormLoading(object sender, EventArgs e)
        {
			comboBox1.Items.AddRange(presenter.loadDevices().ToArray());
			comboBox1.SelectedIndex = 0; // By default pasirinktas bus pirmas objektas comboBox'e
		}

        private void SelectCamera(object sender, EventArgs e)
        {

        }

        private void CameraClick(object sender, EventArgs e)
        {
			presenter.CameraClick(comboBox1.SelectedIndex, NewFrame);
		}

		private void NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			Bitmap video = (Bitmap)eventArgs.Frame.Clone();     //Sukuriame kadro bitmap'ą
			pictureBox.Image = video;                          //Ir jį ištransliuojame picturBox elemente
		}

		private void CaptureClick(object sender, EventArgs e)
        {
            pictureBox.Image.Save(PATH + "IMG" + DateTime.Now.ToString("hhmmss") + ".jpg", ImageFormat.Jpeg);

        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
			presenter.closeForm(); //Išjungus programą išsijungs ir kamera.
        }

        private void ReportButtonClick(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog();
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FindYourCarButtonClick(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm();
            findForm.ShowDialog();
        }

        private void MyGalleryClick(object sender, EventArgs e)
        {
            GalleryForm galleryForm = new GalleryForm();
            galleryForm.ShowDialog();
        }
    }
}
