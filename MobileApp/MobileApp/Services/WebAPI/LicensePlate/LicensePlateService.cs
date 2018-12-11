using Models.Cars;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileApp.Services.WebAPI.LicensePlate
{
    public class LicensePlateService : BaseService
    {
        private static LicensePlateService instance;

        private LicensePlateService() : base()
        {
        }

        public static LicensePlateService GetInstance()
        {
            if (instance == null)
            {
                return instance = new LicensePlateService();
            }
            else
            {
                return instance;
            }
        }

        public async Task<CarStatus> CheckCar(string licensePlate)
        {
            HttpResponseMessage response = await HttpClient.GetAsync("api/numbers");
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CarStatus>(jsonString);
        }
    }
}
