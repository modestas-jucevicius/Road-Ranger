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
using Road_rangerVS.Report;

namespace Road_rangerVS.Presenters
{
	class MainPresenter
	{
		private MainModel model;

		public MainPresenter()
		{
			model = new MainModel();
		}

		// Analizuoja nuotrauką, esančią vietoje imagePath, ir parodo rezultatą konsolėje
		public async Task getCarInfo(string imagePath)
		{
			ICarRecognizer recognizer = new OpenALPRRecognizer();
			ICarParser parser = new OpenALPRParser();
			ICarStatusRequester requester = EPolicijaAPIRequester.GetInstance();
            ReportModel report = new ReportModel();

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
                if(car.Status == CarStatus.STOLEN || car.Status == CarStatus.STOLEN_PLATE)
                {
                    //report.SendMail("mappuab@gmail.com", "Vagyste", car.toReport());
                    new MailReportSender().SendGeneretedMail(car);
                }
                model.carData.Put(car);
                if (!isSaved)
                {
                    timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    path = System.Environment.CurrentDirectory + @"\Images\" + car.Id.ToString() + ".jpg";
                    bitmap.Save(path);

                    isSaved = true;
                }

                Images.Image image = new Images.Image(car.Id, timestamp, path);
                model.imageData.Put(image);
			}
        }

        public List<string> loadDevices()
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

		public void closeForm() //Išjungus programą išsijungs ir kamera.
		{
			if (this.model.finalVideo.IsRunning == true)
			{
				this.model.finalVideo.Stop();
			}
		}
	}
}
