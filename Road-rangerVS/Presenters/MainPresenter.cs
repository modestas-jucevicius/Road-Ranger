﻿using System;
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
        private UserFileSystem userFileSystem = new UserFileSystem();
        private MainModel model;
        private ReportModel report;
        private OpenALPRRecognizer recognizer = new OpenALPRRecognizer();
        public Label scoreLabel;
        private ICarParser parser = new OpenALPRParser();
        private ICarStatusRequester requester = EPolicijaAPIRequester.GetInstance();
        private readonly string picturePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Pictures\";     // ~\Pictures\
        public User loggedInUser = new User(0, "username", "password", "name", 0);

        public MainPresenter(Label scoreLabel)
        {
            model = new MainModel();
            report = new ReportModel();
            User user = userFileSystem.FindById(loggedInUser.id);
            if(user != null)
            {
                loggedInUser.score = user.score;
                scoreLabel.Text = "Score: " + loggedInUser.score.ToString();
            }
            else
            {
                userFileSystem.Put(loggedInUser);
            }
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
                FrameRecognition.isRunning = false;
                List<Car> cars = parser.Parse(result);
                if (cars.Count == 0)
                {
                    return;
                }

                bool isSaved = false;
                long timestamp = 0;
                string path = "";
                foreach (Car car in cars)
                {
                    car.Status = await requester.AskCarStatus(car.LicensePlate);
                    loggedInUser.IncreaseScore(Evaluation.Evaluate(car));
                    scoreLabel.Text = "Score: " + loggedInUser.score.ToString();
                    userFileSystem.Update(loggedInUser.id, loggedInUser);
                    ShowReportMessage(car);
                    SaveData(car, ref isSaved, ref timestamp, ref path, ref video);
                }
            }
        }

        private void ShowReportMessage(Car car)
        {
            String message = "";
            if (car.Status.Equals(CarStatus.STOLEN) || car.Status.Equals(CarStatus.STOLEN_PLATE))
            {
                if (car.Status == CarStatus.STOLEN)
                {
                    message = "You found a stolen car with license plate: " + car.LicensePlate + "! Are you sure you want to report about it?";
                }
                else if (car.Status == CarStatus.STOLEN_PLATE)
                {
                    message = "You found a stolen license plate: " + car.LicensePlate + "! Are you sure you want to report about it?";
                }

                DialogResult foundResult = System.Windows.Forms.MessageBox.Show(message, "Found car message", MessageBoxButtons.YesNo);
                if (foundResult.Equals(DialogResult.Yes))
                {
                    car.IsReported = true;
                    report.SendGeneratedMail(car);
                }
            }
            else
            {
                message = "You found a not stolen car with license plate: " + car.LicensePlate + "!";
                MessageBox.Show(message, "Found car message");
            }
        }

        // Išsaugo view.Frame vaizdą vietoje path
        public void SaveFrameImage(IMainView view)
        {
            Image image = view.Frame;
            image.Save(picturePath + "IMG" + DateTime.Now.ToString("hhmmss") + ".jpg", ImageFormat.Jpeg);
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
                loggedInUser.IncreaseScore(Evaluation.Evaluate(car));
                scoreLabel.Text = "Score: " + loggedInUser.score.ToString();
                userFileSystem.Update(loggedInUser.id, loggedInUser);
                ShowReportMessage(car);
                SaveData(car, ref isSaved, ref timestamp, ref path, ref bitmap);
            }
        }

        // Išsaugo automobilio (car) duomenis ir užfiksuotą jos nuotrauką
        private void SaveData(Car car, ref bool isSaved, ref long timestamp, ref string path, ref Bitmap bitmap)
        {
            model.carData.Put(car);
            if (!isSaved)
            {
                timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Storage\Images\" + car.Id.ToString() + ".jpg";
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
