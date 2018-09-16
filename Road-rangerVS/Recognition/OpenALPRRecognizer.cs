using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS
{
    class OpenALPRRecognizer : Recognizer
    {
        private const string SECRET_KEY = "sk_c9dd80b203f110a25a3dcb5b";

        private static readonly HttpClient client = new HttpClient();

        public async Task<string> Recognize(string imagePath)
        {
            Byte[] bytes = File.ReadAllBytes(imagePath);
            string imagebase64 = Convert.ToBase64String(bytes);

            var content = new StringContent(imagebase64);

            var response = await client.PostAsync("https://api.openalpr.com/v2/recognize_bytes?recognize_vehicle=1&country=eu&secret_key=" + SECRET_KEY, content).ConfigureAwait(false);

            var buffer = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            var byteArray = buffer.ToArray();
            var responseString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);

            return responseString;
        }

    }
}
