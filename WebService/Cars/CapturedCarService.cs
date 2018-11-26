using Models.Cars;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebService.Cars;

namespace WebService.WebService
{
    public class CapturedCarService : BaseService
    {
        private CapturedCarParser parser = new CapturedCarParser();
        private static CapturedCarService instance;

        public CapturedCarService() : base()
        {
        }

        public static CapturedCarService GetInstance()
        {
            if (instance == null)
            {
                return instance = new CapturedCarService();
            }
            else
            {
                return instance;
            }
        }

        public async Task<List<CapturedCar>> GetAll()
        {
            HttpResponseMessage response = await HttpClient.GetAsync("api/cars/all");
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            return parser.Parse(jsonString);
        }

        public async Task<List<CapturedCar>> GetByLicensePlateAsync(string licensePlate)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(String.Format("api/cars/get?licenseplate={0}", licensePlate));
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            return parser.Parse(jsonString);
        }

        public async Task<List<CapturedCar>> GetByUserId(int id)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(String.Format("api/cars/byuser?id={0}", id));
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            return parser.Parse(jsonString);
        }

        public async Task<bool> Add(CapturedCar car)
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/cars/add", new
            {
                Id = car.Id,
                UserId = car.UserId,
                LicensePlate = car.LicensePlate,
                ColorName = car.ColorName,
                MakeName = car.MakeName,
                Model = car.Model,
                BodyType = car.BodyType,
                Year = car.Year,
                IsReported = car.IsReported,
                Status = car.Status,
                Image = car.Image
            });
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Remove(int id)
        {
            HttpResponseMessage response = await HttpClient.DeleteAsync(String.Format("api/cars/remove?id={0}", id));
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }

    }
}
