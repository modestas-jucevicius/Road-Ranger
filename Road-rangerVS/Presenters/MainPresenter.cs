using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using Road_rangerVS.Models;
using Road_rangerVS.OutsideAPI;
using Road_rangerVS.Recognition;
using AForge.Video;
using AForge.Video.DirectShow;

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

			string result = await recognizer.Recognize(imagePath);
			List<Car> cars = parser.Parse(result);
			if (cars.Count() == 0)
			{
				throw new ParseException("No cars found");
			}

			foreach (Car car in cars)
			{
				car.status = await requester.AskCarStatus(car.licensePlate);
				Console.WriteLine(car.licensePlate);
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
