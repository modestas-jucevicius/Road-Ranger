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
            string uri = "api/numbers/check?licensePlate=" + licensePlate;
            HttpResponseMessage response = await HttpClient.PostAsync(uri, null);
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CarStatus>(jsonString);
        }
    }
}
