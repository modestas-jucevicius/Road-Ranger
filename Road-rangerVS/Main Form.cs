using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using Road_rangerVS.Data;
using Road_rangerVS.OutsideAPI;
using Road_rangerVS.Recognition;
using Road_rangerVS.Search;

namespace Road_rangerVS
{
	public partial class Form1 : Form
	{
        FileSystem<Car> file;
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;
        private string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Pictures\\";     // ~/bin/Debug/Pictures/
		public Form1()
		{
			InitializeComponent();
            file = new FileSystem<Car>(1);
           ReportForm reportForm = new ReportForm();
        }

		private void label1_Click(object sender, EventArgs e)
		{

		}

        private void UploadButtonClick(object sender, EventArgs e)
        {
            string imagePath = filePath.Text;
			if (!File.Exists(imagePath))
			{
				MessageBox.Show("Wrong Image Path!");
			}
			else
			{
				Recognize(imagePath);
			}
        }

        // Analizuoja nuotrauką, esančią vietoje imagePath, ir parodo rezultatą konsolėje
        private async Task Recognize(string imagePath)
        {
            ICarRecognizer recognizer = new OpenALPRRecognizer();
            string result = await recognizer.Recognize(imagePath);

            ICarParser parser = new OpenALPRParser();

            ICarStatusRequester requester = EPolicijaAPIRequester.GetInstance();
            if (!parser.IsError(result))
			{
				List<Car> cars = parser.Parse(result);

				foreach (Car car in cars)
				{
                    car.status = await requester.AskCarStatus(car.licensePlate);
                }

				if (cars.Count() == 0)
				{
					MessageBox.Show("Wrong Image!");
				}
			}
			else
			{
				MessageBox.Show("Wrong Image!");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainFormLoading(object sender, EventArgs e)
        {
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice); //Surandame visas kameras sistemoje

            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name);   //comboBox'e pateikiame visas rastas kameras sistemoje
            }

            comboBox1.SelectedIndex = 0;                        // By default pasirinktas bus pirmas objektas comboBox'e
            FinalVideo = new VideoCaptureDevice();              // Sukuriame VideoCaptureDevice instance'ą
        }

        private void SelectCamera(object sender, EventArgs e)
        {

        }

        private void CameraClick(object sender, EventArgs e)
        {
            if (FinalVideo.IsRunning == true) FinalVideo.Stop(); //Jei kamera įjungta, tai paspaudus mygtuką "Camera" ją išjungiame
            else                                                 //Kitu atveju, kamerą paleidžiame         
            {
                FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[comboBox1.SelectedIndex].MonikerString);
                FinalVideo.NewFrame += FinalVideo_NewFrame; 
                FinalVideo.Start();
            }
            
        }


        private void CaptureCLick(object sender, EventArgs e)
        {
            pictureBox.Image.Save(path + "IMG" + DateTime.Now.ToString("hhmmss") + ".jpg", ImageFormat.Jpeg);

        }

        private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap video = (Bitmap)eventArgs.Frame.Clone();     //Sukuriame kadro bitmap'ą
            pictureBox.Image = video;                          //Ir jį ištransliuojame picturBox elemente
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalVideo.IsRunning == true) FinalVideo.Stop(); //Išjungus programą išsijungs ir kamera.
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
            FindForm reportForm = new FindForm();
            reportForm.ShowDialog();
        }

        private void myHistory_Click(object sender, EventArgs e)
        {

        }
    }
}
