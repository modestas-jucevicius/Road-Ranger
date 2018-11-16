using RoadRangerBackEnd.Users;
using RoadRangerBackEnd.Data;

namespace RoadRangerBackEnd.Authorization
{
	public class AuthorizationService
	{
		private static AuthorizationService instance;
		private User CurrentUser { get; set; }
		private UserFileSystem UserFileSystem { get; set; }
		private AuthorizationService() {
			UserFileSystem = UserFileSystem.GetInstance();
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

		public User GetCurrentUser()
		{
			return this.CurrentUser;
		}

		public User Login() {
			 return CurrentUser = new User(0, "username", "password", "name", 0, false, false, false);
		}

		public void SyncCurrentUserToData()
		{
			User savedUser = UserFileSystem.FindById(this.CurrentUser.Id);
			if (savedUser != null)
			{
				this.CurrentUser.Score = savedUser.Score;
                this.CurrentUser.Boosts = savedUser.Boosts;
			}
			else
			{
				UserFileSystem.Put(this.CurrentUser);
			}
		}
	}
}
