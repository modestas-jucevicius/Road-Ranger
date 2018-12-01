using System.Net.Http;
using System.Net.Http.Headers;

namespace Services.WebAPI
{
    public class BaseService
    {
        protected HttpClient HttpClient = new HttpClient()
        {
            BaseAddress = new System.Uri("http://localhost:50472/"),
        };

        public BaseService()
        {
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
