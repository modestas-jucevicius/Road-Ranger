using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Road_rangerVS.OutsideAPI
{
	class EPolicijaAPI
	{
		private static readonly HttpClient client = new HttpClient();
		private static readonly string URL = "https://www.epolicija.lt/itpr_paieska/transportas_lt.php";
		private static EPolicijaAPI instance;

		public static EPolicijaAPI getInstance()
		{
			if (instance != null)
			{
				return instance;
			}
			else
			{
				instance = new EPolicijaAPI();
				return instance;
			}
		}

		private EPolicijaAPI() { }

		public async Task<Boolean> IsCarStolen(string licenseNumbers) {
			var body = new Dictionary<string, string>
			{
				{ "knr", "" },
				{ "opt", "1" },
				{ "varnr", "" },
				{ "vnr", licenseNumbers }
			};

			var content = new FormUrlEncodedContent(body);

			var response = await client.PostAsync(URL, content);

			var responseString = await response.Content.ReadAsStringAsync();
			return parsePhpIfStolen(responseString);
		}

		private Boolean parsePhpIfStolen(string phpString) {
			if (phpString.Contains("IEŠKOMA (-AS) NĖRA"))
			{
				return false;
			}
			else if (phpString.Contains("IEŠKOMA."))
			{
				return true;
			}
			else
			{
				throw new LicenceNumberParseException("Couldn't Parse If Stolen.");
			}

		}
	}

	class LicenceNumberParseException : Exception {
		public LicenceNumberParseException(string message) : base(message)
		{
		}
	}
}
