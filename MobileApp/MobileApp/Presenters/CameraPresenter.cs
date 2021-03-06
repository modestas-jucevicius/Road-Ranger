﻿using MobileApp.Views;
using Models.Cars;
using Plugin.Media.Abstractions;
using MobileApp.Services.Recognition;
using MobileApp.Services.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using MobileApp.Services.WebAPI.Authorization;
using MobileApp.Services.WebAPI.LicensePlate;
using MobileApp.Manager;
using System.Threading.Tasks;
using Models.Users;
using System.Diagnostics;
using MobileApp.Services.Maps;
using Xamarin.Forms.Maps;
using Models.Images;
using Image = Models.Images.Image;
using MobileApp.Services.WebAPI.Cars;
using System.Threading;

namespace MobileApp.Presenters
{
    class CameraPresenter : BasePresenter
    {
        private CameraPage page;
        private StoreCameraMediaOptions cameraOptions;
        private readonly ICarParser parser = new OpenALPRParser();
        private readonly ITextValidator validator = new LicensePlateValidator();
        private readonly AuthorizationService authorization = AuthorizationService.GetInstance();
        private readonly LicensePlateService licensePlateService = LicensePlateService.GetInstance();
        private readonly Random rand = new Random();
        private readonly ImageFactory imageFactory = ImageFactory.GetInstance();
        private readonly CarFactory carFactory = CarFactory.GetInstance();
        private readonly MapTool mapTool = new MapTool(null);
        private readonly CapturedCarService capturedCarService = CapturedCarService.GetInstance();
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        public CameraPresenter(CameraPage page)
        {
            this.page = page;
            this.cameraOptions = new StoreCameraMediaOptions();
            var filename = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).ToString(), "RoadRanger");
            Directory.CreateDirectory(filename);

            Initialize();
        }
        
        private void Initialize()
        {
            CameraPage.cameraButton.Clicked += CameraButton_Clicked;
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            
            if (Plugin.Media.CrossMedia.Current.IsCameraAvailable)
            {
                await _semaphoreSlim.WaitAsync();
                MediaFile photo = null;
                try
                {
                    photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                if (photo != null)
                {
                    CameraPage.activityIndicator.IsRunning = true;
                    CameraPage.cameraImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                    Byte[] imageBytes = ReadFully(photo.GetStream());
                    List<Car> cars = await GetPlateStatus(imageBytes);

                    if (cars != null && cars[0] != null)
                    {
                        CameraPage.plateLabel.Text = cars[0].LicensePlate + "  " + cars[0].Status;
                        String path = await SaveImageAsync(imageBytes, cars[0]);                                  //Issaugo nuotrauka
                        Image image = await ProcessImageAsync(path, cars[0]);
                        CapturedCar capturedCar = carFactory.CreateCapturedCar(cars[0], image);
                        try
                        {
                            await capturedCarService.Add(capturedCar);
                        }
                        catch(Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                        _semaphoreSlim.Release();
                        CameraPage.activityIndicator.IsRunning = false;
                    }
                    else
                    {
                        CameraPage.plateLabel.Text = "Car not found...";
                        _semaphoreSlim.Release();
                        CameraPage.activityIndicator.IsRunning = false;
                    }

                }
            }
        }

        public static byte[] ReadFully(Stream input)                        //Konvertuoja memory stream i byte array
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private async Task<List<Car>> GetPlateStatus(Byte[] imageBytes)
        {
            string result = await FrameRecognition.Recognition(imageBytes);
            try
            {
                List<Car> cars = parser.Parse(result);
                if (cars.Count > 0)
                {
                    cars[0].Status = await licensePlateService.CheckCar(cars[0].LicensePlate);
                    cars[0].Id = rand.Next(1, 999999).ToString();
					          User user = await authorization.GetCurrentUser();
					          cars[0].UserId = user.ID;
					          return cars;
                }

            }
            catch (ParseException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        private async void ProcessFoundCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                if (validator.IsValid(car.LicensePlate))
                {
                    try
                    {
                        car.Status = await licensePlateService.CheckCar(car.LicensePlate);
                    }
                    catch (Exception)
                    {
                        await DialogAlertManager.ShowInternalDialogAlert(page);
                    }
                }
                else
                {
                    Console.WriteLine(car.LicensePlate);
                }
            }
        }

        private async Task<String> SaveImageAsync(Byte[] image, Car car)
        {
            var filename = Path.Combine(Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).ToString(), "RoadRanger"), car.Id + ".jpg");
            var fileOutputStream = new Java.IO.FileOutputStream(filename);
            await fileOutputStream.WriteAsync(image);
            
            return filename;
        }

        private async Task<Image> ProcessImageAsync(String path, Car car)
        {
            Position pos = await mapTool.GetLocation();
            return imageFactory.CreateImage(rand.Next(1, 999999).ToString(), car.Id, DateTime.Now.Ticks, path, pos);
        }


    }
}
