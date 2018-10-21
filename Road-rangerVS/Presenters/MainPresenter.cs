using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Road_rangerVS.Models;
using Road_rangerVS.OutsideAPI;
using Road_rangerVS.Recognition;
using AForge.Video;
using AForge.Video.DirectShow;
using Road_rangerVS.Views;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Road_rangerVS.Presenters
{
    class MainPresenter
    {
        private MainModel model;
        private ReportModel report;
        private OpenALPRRecognizer recognizer = new OpenALPRRecognizer();
        private ICarParser parser = new OpenALPRParser();
        private ICarStatusRequester requester = EPolicijaAPIRequester.GetInstance();

        public MainPresenter()
        {
            model = new MainModel();
            report = new ReportModel();
        }

        // Transliuoja naują kadrą į view.Frame
        public async void NewFrame(IMainView view, NewFrameEventArgs eventArgs)
        {
            Bitmap video = (Bitmap)eventArgs.Frame.Clone(); //Sukuriame kadro bitmap'ą
            view.Frame = video;                             //Ir jį ištransliuojame view.Frame elemente
            Bitmap frameCopy = (Bitmap)eventArgs.Frame.Clone();
            
            if(FrameRecognition.isRunning == false)
            {
                Byte[] imageBytes = ImageToByte(frameCopy);
                string result = await FrameRecognition.Recognition(imageBytes);
                FrameRecognition.isRunning = false;
                List<Car> cars = parser.Parse(result);
                if (cars.Count == 0)
                {
                    Console.WriteLine("Auto nerasta");
                    return;
                }

                bool isSaved = false;
                long timestamp = 0;
                string path = "";
                foreach (Car car in cars)
                {
                    car.Status = await requester.AskCarStatus(car.LicensePlate);
                    SaveData(car, isSaved, timestamp, path, video);
                }
            }
        }

        // Išsaugo view.Frame vaizdą vietoje path
        public void SaveFrameImage(IMainView view, string path)
        {
            view.Frame.Save(path + "IMG" + DateTime.Now.ToString("hhmmss") + ".jpg", ImageFormat.Jpeg);
        }

        // Ieško automobilio nuotraukos kompiuterio aplankaluose
        public void Browse(IMainView view)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg"; // failo tipai, kurie bus naudojami
            dialog.Multiselect = false; // true - galima pridėti daugiau negu viena failą, false - galima pridėti tik 1 failą
            if (dialog.ShowDialog() == DialogResult.OK) // jei vartotojas paspaudžia OK
            {
                String path = dialog.FileName; // gauna failo vardą
                view.Path = path;           // laukui filePath priskiriama path reikšmė
            }
        }

        // Analizuoja nuotrauką, esančią vietoje imagePath, ir parodo rezultatą konsolėje
        public async Task GetCarInfo(string imagePath)
		{
            string result = await recognizer.Recognize(imagePath);
			List<Car> cars = parser.Parse(result);
			if (cars.Count() == 0)
			{
				throw new ParseException("No cars found");
			}

            Bitmap bitmap = new Bitmap(imagePath);

            bool isSaved = false;
            long timestamp = 0;
            string path = "";
            foreach (Car car in cars)
			{
                car.Status = await requester.AskCarStatus(car.LicensePlate);
                SaveData(car, isSaved, timestamp, path, bitmap);
            }
        }

        // Išsaugo automobilio (car) duomenis ir užfiksuotą jos nuotrauką
        private void SaveData(Car car, bool isSaved, long timestamp, string path, Bitmap bitmap)
        {
            model.carData.Put(car);
            if (!isSaved)
            {
                timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                path = Environment.CurrentDirectory + @"\Images\" + car.Id.ToString() + ".jpg";
                bitmap.Save(path);

                isSaved = true;
            }

            Images.Image image = new Images.Image(car.Id, timestamp, path);
            model.imageData.Put(image);
        }

        public List<string> LoadDevices()
		{
			List<string> deviceNames = new List<string>();
			this.model.videoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice); //Surandame visas kameras sistemoje

			foreach (FilterInfo videoCaptureDevice in this.model.videoCaptureDevices)
			{
				deviceNames.Add(videoCaptureDevice.Name);   //comboBox'e pateikiame visas rastas kameras sistemoje
			}

			this.model.finalVideo = new VideoCaptureDevice();              // Sukuriame VideoCaptureDevice instance'ą
			return deviceNames;
		}

		public void CameraClick(int selectedIndex, NewFrameEventHandler newFrame)
		{
			if (this.model.finalVideo.IsRunning == true)
			{
				this.model.finalVideo.Stop(); //Jei kamera įjungta, tai paspaudus mygtuką "Camera" ją išjungiame
			}
			else                                                 //Kitu atveju, kamerą paleidžiame         
			{
				this.model.finalVideo = new VideoCaptureDevice(this.model.videoCaptureDevices[selectedIndex].MonikerString);
				this.model.finalVideo.NewFrame += newFrame;
				this.model.finalVideo.Start();
			}
		}

		public void CloseForm() //Išjungus programą išsijungs ir kamera.
		{
			if (this.model.finalVideo.IsRunning == true)
			{
				this.model.finalVideo.Stop();
			}
		}

        public static byte[] ImageToByte(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
