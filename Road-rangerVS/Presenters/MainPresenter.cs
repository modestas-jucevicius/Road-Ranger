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
using Road_rangerVS.Users;
using Road_rangerVS.Data;
using Road_rangerVS.Score;

namespace Road_rangerVS.Presenters
{
    class MainPresenter
    {
        private MainModel model;
        private ReportModel report;
        private OpenALPRRecognizer recognizer = new OpenALPRRecognizer();
        public Label scoreLabel;
        private ICarParser parser = new OpenALPRParser();
        private ICarStatusRequester requester = EPolicijaAPIRequester.GetInstance();

        public MainPresenter(Label scoreLabel)
        {
            model = new MainModel();
            report = new ReportModel();
			scoreLabel.Text = "Score: " + this.model.GetUserScore().ToString();
			this.scoreLabel = scoreLabel;
        }

		// Transliuoja naują kadrą į view.Frame
		public async void NewFrame(IMainView view, NewFrameEventArgs eventArgs)
        {
            Bitmap video = (Bitmap)eventArgs.Frame.Clone(); //Sukuriame kadro bitmap'ą
            view.Frame = video;                             //Ir jį ištransliuojame view.Frame elemente
            Bitmap frameCopy = (Bitmap)eventArgs.Frame.Clone(); //Reikalinga, nes neleidziama naudot to paties bitmap'o keliuose threaduose
            //Atpazistame automobilius
            if(FrameRecognition.isRunning == false)
            {
                Byte[] imageBytes = ImageToByte(frameCopy);
                string result = await FrameRecognition.Recognition(imageBytes);
				try
				{
					List<Car> cars = parser.Parse(result);
					ProcessFoundCars(cars, video);
				}
				catch (ParseException exception)
				{
					MessageBox.Show(exception.Message);
				}
			}
        }

        // Išsaugo view.Frame vaizdą vietoje path
        public void SaveFrameImage(IMainView view)
        {
			this.model.SaveImage(view.Frame);
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
			try
			{
				List<Car> cars = parser.Parse(result);
				if (cars.Count == 0)
				{
					throw new ParseException("No cars found");
				}

				Bitmap bitmap = new Bitmap(imagePath);
				ProcessFoundCars(cars, bitmap);
			}
			catch (ParseException exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

        public List<string> LoadDevices()
		{
			List<string> deviceNames = new List<string>();
			this.model.VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice); //Surandame visas kameras sistemoje

			foreach (FilterInfo videoCaptureDevice in this.model.VideoCaptureDevices)
			{
				deviceNames.Add(videoCaptureDevice.Name);   //comboBox'e pateikiame visas rastas kameras sistemoje
			}

			this.model.FinalVideo = new VideoCaptureDevice();              // Sukuriame VideoCaptureDevice instance'ą
			return deviceNames;
		}

		public void CameraClick(int selectedIndex, NewFrameEventHandler newFrame)
		{
			if (this.model.FinalVideo.IsRunning == true)
			{
				this.model.FinalVideo.Stop(); //Jei kamera įjungta, tai paspaudus mygtuką "Camera" ją išjungiame
			}
			else                                                 //Kitu atveju, kamerą paleidžiame         
			{
				this.model.FinalVideo = new VideoCaptureDevice(this.model.VideoCaptureDevices[selectedIndex].MonikerString);
				this.model.FinalVideo.NewFrame += newFrame;
				this.model.FinalVideo.Start();
			}
		}

		public void CloseForm() //Išjungus programą išsijungs ir kamera.
		{
			if (this.model.FinalVideo.IsRunning == true)
			{
				this.model.FinalVideo.Stop();
			}
		}

		private async void ProcessFoundCars(List<Car> cars, Bitmap source)
		{
			bool isSaved = false;
			long timestamp = 0;
			string path = "";
			foreach (Car car in cars)
			{
				car.Status = await requester.AskCarStatus(car.LicensePlate);
				this.model.IncreaseUserScore(Evaluation.Evaluate(car));
				scoreLabel.Text = "Score: " + this.model.GetUserScore().ToString();
				ShowReportMessage(car);
				model.SaveData(car, ref isSaved, ref timestamp, ref path, ref source);
			}
		}

		private void ShowReportMessage(Car car)
		{
			string message;
			switch (car.Status)
			{
				case CarStatus.STOLEN:
					message = "You found a stolen car with license plate: " + car.LicensePlate + "! Are you sure you want to report about it?";
					DisplayStolenDialog(message, car);
					break;
				case CarStatus.STOLEN_PLATE:
					message = "You found a stolen license plate: " + car.LicensePlate + "! Are you sure you want to report about it?";
					DisplayStolenDialog(message, car);
					break;
				case CarStatus.NOT_STOLEN:
					message = "You found a not stolen car with license plate: " + car.LicensePlate + "!";
					MessageBox.Show(message, "Found car message");
					break;
			}
		}

		private void DisplayStolenDialog(string message, Car car)
		{
			DialogResult foundResult = System.Windows.Forms.MessageBox.Show(message, "Found car message", MessageBoxButtons.YesNo);
			if (foundResult.Equals(DialogResult.Yes))
			{
				car.IsReported = true;
				report.SendGeneratedMail(car);
			}
		}

		private byte[] ImageToByte(Image img)
		{
			using (var stream = new MemoryStream())
			{
				img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
				return stream.ToArray();
			}
		}
	}
}
