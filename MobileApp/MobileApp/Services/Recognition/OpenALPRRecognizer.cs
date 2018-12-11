using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services.Recognition
{
    public class OpenALPRRecognizer : ICarRecognizer
    {
        private const string SECRET_KEY = "sk_f2ff09a93e3a0f82996a55c8";    // openalpr vartotojo privatus raktas

        private static HttpClient client = new HttpClient();

        public async Task<String> Recognize(Byte[] image)
        {
            string imagebase64 = Convert.ToBase64String(image); // konvertuoja baitų masyvą į base64 string'ą

            var content = new StringContent(imagebase64);   // sukuria StringContent objektą, kuris skirtas komunikuoti su API persiunčiant duomenis

            // await - palaukia, kol užduotis(metodas PostAsync) yra baigiama ir tik tada inicijuoja kintamąjį response
            // kreipiasi į openalpr API ir laukia atsakymo iš jo
            // gavus atsakymą yra inicijuojamas kintamasis response
            var response = await client.PostAsync("https://api.openalpr.com/v2/recognize_bytes?recognize_vehicle=1&country=eu&secret_key=" + SECRET_KEY, content).ConfigureAwait(false);

            // skaito užklausos atsakymą - Content, į buffer
            var buffer = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            var byteArray = buffer.ToArray();   // buffer duomenis konvertuoja į byteArray masyvą
            var responseString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);   // masyvo byteArray duomenis knovertuoja į string eilutę responseString

            return responseString;
        }

        // Kreipiasi į openalpr API ir grąžina užklausos atsakymą JSON formate - string
        public async Task<string> Recognize(string imagePath)
        {
            Byte[] imageBytes = getBytesFromPath(imagePath);
            string cars = await Recognize(imageBytes);
            return cars;
        }

        private Byte[] getBytesFromPath(string imagePath)   // Konvertuoja imagePath i baitu masyva
        {
            Byte[] bytes = File.ReadAllBytes(imagePath);
            return bytes;
        }

    }
}
