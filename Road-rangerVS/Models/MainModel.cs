using System;
using System.Drawing;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.IO;
using RoadRangerBackEnd.Data;
using RoadRangerBackEnd.Authorization;
using RoadRangerBackEnd.Users;
using RoadRangerBackEnd.Cars;

namespace Road_rangerVS.Models
{
	class MainModel
	{
		public ICarData CarData { get; set; }
        public IImageData ImageData { get; set; }
		public FilterInfoCollection VideoCaptureDevices { get; set; }
		public VideoCaptureDevice FinalVideo { get; set; }
		private readonly string PicturePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Pictures\";     // ~\Pictures\
		private AuthorizationService AuthorizationService = AuthorizationService.GetInstance();
		private UserFileSystem UserFileSystem = UserFileSystem.GetInstance();

		public MainModel()
		{
            CarData = new CarFileSystem();
            ImageData = new ImageFileSystem();
			AuthorizationService.Login();
        }

		public int GetUserScore()
		{
			User currentUser = AuthorizationService.GetCurrentUser();
            AuthorizationService.SyncCurrentUserToData();
			return currentUser.Score;
			
		}

		public void IncreaseUserScore(int gainedPoints)
		{
			User currentUser = AuthorizationService.GetCurrentUser();
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

            RoadRangerBackEnd.Images.Image image = new RoadRangerBackEnd.Images.Image(car.Id, timestamp, path);
			ImageData.Put(image);
		}
	}
}
