using Microcharts;
using Models.Statistics;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.WebAPI.Statistic
{
    public class StatisticService : BaseService
    {
        private static StatisticService instance;

        private StatisticService() : base()
        {
        }

        public static StatisticService GetInstance()
        {
            if (instance == null)
            {
                return instance = new StatisticService();
            }
            else
            {
                return instance;
            }
        }
        
        public async Task<List<StatisticEntry>> GetEntries(int type)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(string.Format("api/statistic/entries?type={0}", type));
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<StatisticEntry>>(jsonString);
        }
    }
}
