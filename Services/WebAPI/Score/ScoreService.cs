using Models.Users;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.WebAPI.Score
{
    public class ScoreService : BaseService
    {
        private static ScoreService instance;

        private ScoreService() : base()
        {
        }

        public static ScoreService GetInstance()
        {
            if (instance == null)
            {
                return instance = new ScoreService();
            }
            else
            {
                return instance;
            }
        }

        public async Task<List<User>> GetTop()
        {
            HttpResponseMessage response = await HttpClient.GetAsync("api/score/top");
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<User>>(jsonString);
        }

        public async Task<int> Boost30p(User user)
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/score/boost30p", new
            {
                Id = user.ID,
                Username = user.Username,
                Password = user.Password,
                Score = user.Score,
                BoostType = user.BoostType
            });
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(jsonString);
        }

        public async Task<int> Boost50p(User user)
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/score/boost50p", new
            {
                Id = user.ID,
                Username = user.Username,
                Password = user.Password,
                Score = user.Score,
                BoostType = user.BoostType
            });
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(jsonString);
        }

        public async Task<int> BoostDouble(User user)
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/score/boostdouble", new
            {
                Id = user.ID,
                Username = user.Username,
                Password = user.Password,
                Score = user.Score,
                BoostType = user.BoostType
            });
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(jsonString);
        }
    }
}
