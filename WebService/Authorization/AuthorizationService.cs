using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using Models.Users;

namespace WebService.Authorization
{
	public class AuthorizationService : BaseService
	{
		private static AuthorizationService instance;
		
		private User CurrentUser { get; set; }
		private AuthorizationService() : base()
		{
		}

		public static AuthorizationService GetInstance()
		{
			if (instance == null)
			{
				return instance = new AuthorizationService();
			}
			else
			{
				return instance;
			}
		}

		public async Task<User> GetCurrentUser()
		{
			HttpResponseMessage response = await HttpClient.GetAsync("api/user");
			response.EnsureSuccessStatusCode();
			string jsonString = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<User>(jsonString);
		}

		public async Task<String> Login(string username, string password)
		{
			HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/user/login", new
			{
				Username = username,
				Password = password
			});
			response.EnsureSuccessStatusCode();
			String token = JsonConvert.DeserializeObject<String>(await response.Content.ReadAsStringAsync());
			HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
			return token;
		}

		public async Task<String> Register(string username, string password)
		{
			HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/user", new
			{
				Username = username,
				Password = password
			});
			response.EnsureSuccessStatusCode();
			String token = JsonConvert.DeserializeObject<String>(await response.Content.ReadAsStringAsync());
			HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
			return token;
		}

		public async void UpdateUser(User user)
		{
			HttpResponseMessage response = await HttpClient.PutAsJsonAsync("api/user", user);
			response.EnsureSuccessStatusCode();
		}

		public void SetToken(string token)
		{
			HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
		}
	}
}
