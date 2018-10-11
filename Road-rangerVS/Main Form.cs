using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
<<<<<<< HEAD
using Microsoft.Scripting.Hosting;
using Road_rangerVS.OutsideAPI;
using Road_rangerVS.Validation;
=======
using Road_rangerVS.Data;
>>>>>>> InitialFileSystem

namespace Road_rangerVS
{
	public partial class Form1 : Form
	{
        FileSystem file;
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;
        private string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Pictures\\";     // ~/bin/Debug/Pictures/
		public Form1()
		{
			InitializeComponent();
            file = new FileSystem();
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
            Recognizer recognizer = new OpenALPRRecognizer();
            string result = await recognizer.Recognize(imagePath);

            Parser parser = new OpenALPRParser();
			if (!parser.IsError(result))
			{
				List<ParsedCar> cars = parser.Parse(result);

                foreach (ParsedCar car in cars)
				{
<<<<<<< HEAD
                    LicensePlateValidator licensePlateValidator = new LicensePlateValidator();
                    if (licensePlateValidator.isValid(car.licensePlate))
                    {
                        Console.WriteLine(car.getCarStatus());
                    }
                    else
                    {
                        Console.WriteLine(car.licensePlate + " is not valid license.");
                    }
                }
=======
					await car.Display(this.file);
				}
>>>>>>> InitialFileSystem

				if (cars.Count() == 0)
				{
					MessageBox.Show("There is no any car!");
				}
			}
			else
			{
				MessageBox.Show("Something went wrong, try again!");
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
                try
                {
                    CaptureCLick(sender, e);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                FinalVideo.Start();
            }
            
        }

        private void CaptureCLick(object sender, EventArgs e)
        {
            pictureBox.Image.Save(path + "IMG" + DateTime.Now.ToString("hhmmss") + ".jpg", ImageFormat.Jpeg);

            /*
            byte[] bytes = imageToByteArray(pictureBox.Image);
            //Console.WriteLine(System.Text.Encoding.Default.GetString(bytes));

            string someString = Encoding.ASCII.GetString(bytes);

            byte[] bytes2 = Encoding.ASCII.GetBytes(someString);
            string someString2 = Encoding.ASCII.GetString(bytes2);

            Console.WriteLine(someString.Equals(someString2));
            Console.WriteLine(someString2);
            */
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
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

<<<<<<< HEAD
        private void callPythonCode_Click(object sender, EventArgs e)
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string cmd = projectPath + @"\python_car_recognition\deep_learning_object_detection.py";
            string args = @"";

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Python27\python.exe";     // Nustatomas python.exe failas kompiuteryje
            start.Arguments = string.Format("\"{0}\" \"{1}\"", cmd, args);
            start.UseShellExecute = false;                  // Nustatoma, kad nenaudotų OS shell
            start.CreateNoWindow = true;                    // Nustatoma, kad nereikia naujo lango
            start.RedirectStandardOutput = true;            // Kažkoks output'as, sugeneruotas iš python kodo, turi būti gražintas atgal į C sharp (šią) aplikaciją
            start.RedirectStandardError = true;             // Kažkokia klaida (Error, Exception) output'e turi būti grąžinta į C sharp (šią) aplikaciją
            Console.WriteLine("[APP INFO] Python code executed...");
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd();  // Skaito Exception'us iš python kodo
                    string result = reader.ReadToEnd();                 // Skaito rezultatą iš StdOut (pvz: print("test"))
                    Console.WriteLine(result);
                }
            }
            Console.WriteLine("[APP INFO] Python code finished the job...");

=======
        private void reportButton_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
>>>>>>> InitialFileSystem
        }
    }
}
