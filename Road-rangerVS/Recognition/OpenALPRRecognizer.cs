using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS
{
    class OpenALPRRecognizer : ICarRecognizer
    {
        private const string SECRET_KEY = "sk_f2ff09a93e3a0f82996a55c8";    // openalpr vartotojo privatus raktas

        private static HttpClient client = new HttpClient();

        // Kreipiasi į openalpr API ir grąžina užklausos atsakymą JSON formate - string
        public async Task<string> Recognize(string imagePath)
        {
            Byte[] bytes = File.ReadAllBytes(imagePath);        // skaito failo esančio vietoje imagePath reikšmę į baitų masyvą bytes
            string imagebase64 = Convert.ToBase64String(bytes); // konvertuoja baitų masyvą į base64 string'ą

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

    }
}
