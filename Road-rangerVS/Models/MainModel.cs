using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Data;
using Road_rangerVS.Recognition;
using AForge.Video;
using System.Drawing;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using Road_rangerVS.Authorization;
using System.IO;
using Road_rangerVS.Users;

namespace Road_rangerVS.Models
{
	class MainModel
	{
		public ICarData CarData { get; set; }
        public IImageData ImageData { get; set; }
		public FilterInfoCollection VideoCaptureDevices { get; set; }
		public VideoCaptureDevice FinalVideo { get; set; }
		private readonly string PicturePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Pictures\";     // ~\Pictures\
		private AuthorizationService AuthorizationService = AuthorizationService.getInstance();
		private UserFileSystem UserFileSystem = UserFileSystem.GetInstance();

		public MainModel()
		{
            CarData = new CarFileSystem();
            ImageData = new ImageFileSystem();
			AuthorizationService.login();
        }

		public int GetUserScore()
		{
			User currentUser = AuthorizationService.getCurrentUser();
			return currentUser.score;
			
		}

		public void IncreaseUserScore(int gainedPoints)
		{
			User currentUser = AuthorizationService.getCurrentUser();
			currentUser.IncreaseScore(gainedPoints);
			UserFileSystem.Update(currentUser);
		}

		public void SaveImage(Image image)
		{
			image.Save(PicturePath + "IMG" + DateTime.Now.ToString("hhmmss") + ".jpg", ImageFormat.Jpeg);
		}

		// Išsaugo automobilio (car) duomenis ir užfiksuotą jos nuotrauką
		public void SaveData(Car car, ref bool isSaved, ref long timestamp, ref string path, ref Bitmap bitmap)
		{
			CarData.Put(car);
			if (!isSaved)
			{
				timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
				path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Storage\Images\" + car.Id.ToString() + ".jpg";
				bitmap.Save(path);

				isSaved = true;
			}

			Images.Image image = new Images.Image(car.Id, timestamp, path);
			ImageData.Put(image);
		}
	}
}
