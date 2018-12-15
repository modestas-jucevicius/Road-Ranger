using MobileApp.Views;
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

namespace MobileApp.Presenters
{
    class CameraPresenter : BasePresenter
    {
        private CameraPage page;
        private StoreCameraMediaOptions cameraOptions;
        private readonly ICarParser parser = new OpenALPRParser();
        private readonly ITextValidator validator = new LicensePlateValidator();
        private readonly LicensePlateService service = LicensePlateService.GetInstance();
        private readonly AuthorizationService authorization = AuthorizationService.GetInstance();
        private readonly LicensePlateService licensePlateService = LicensePlateService.GetInstance();

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
                    try
                    {
                        car.Status = await service.CheckCar(car.LicensePlate);
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
    }
}
