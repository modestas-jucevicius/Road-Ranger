﻿using MobileApp.Views;
using Models.Cars;
using Plugin.Media.Abstractions;
using Services.Recognition;
using Services.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Services.WebAPI.Authorization;
using Services.WebAPI.LicensePlate;
using Models.Users;
using WebAPIService.EPolicija;

namespace MobileApp.Presenters
{
    class CameraPresenter : BasePresenter
    {
        private CameraPage page;
        private StoreCameraMediaOptions cameraOptions;
        private ICarParser parser = new OpenALPRParser();
        private readonly ITextValidator validator = new LicensePlateValidator();
        private readonly ICarStatusRequester requester = EPolicijaAPIRequester.GetInstance();
        private AuthorizationService authorization = AuthorizationService.GetInstance();
        private LicensePlateService licensePlateService = LicensePlateService.GetInstance();
        //private Evaluation evaluation = new Evaluation();

        public CameraPresenter(CameraPage page)
        {
            this.page = page;
            this.cameraOptions = new StoreCameraMediaOptions();
            Initialize();
        }
        
        private void Initialize()
        {
            CameraPage.cameraButton.Clicked += CameraButton_Clicked;
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
            if (photo != null)
            {
                CameraPage.cameraImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                Byte[] imageBytes = ReadFully(photo.GetStream());
                string plateNumber = await GetPlate(imageBytes);
                CameraPage.plateLabel.Text = plateNumber;

                System.Console.WriteLine(plateNumber);
            }
        }

        public static byte[] ReadFully(Stream input)
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

        private async System.Threading.Tasks.Task<string> GetPlate(Byte[] imageBytes)
        {
            string status = "Car not found!";
            string result = await FrameRecognition.Recognition(imageBytes);
            try
            {
                List<Car> cars = parser.Parse(result);
                ProcessFoundCars(cars);
                if(cars.Count > 0)
                {
                    //await licensePlateService.CheckCar(cars[0].LicensePlate);
                    return cars[0].LicensePlate + " " + cars[0].Status;
                }
                    
            }
            catch (ParseException)
            {
                System.Console.WriteLine("ParseException occured!");
            }
            return status;
        }

        private async void ProcessFoundCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                if (validator.IsValid(car.LicensePlate))
                {
                    car.Status = await requester.AskCarStatus(car.LicensePlate);
                    //TO DO Give user points for cars
                }
                else
                {
                    Console.WriteLine(car.LicensePlate);
                }
            }
        }
    }
}