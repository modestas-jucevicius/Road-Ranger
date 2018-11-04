using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Users;
using Road_rangerVS.Data;

namespace Road_rangerVS.Authorization
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
			 return CurrentUser = new User(0, "username", "password", "name", 0);
		}

		public void SyncCurrentUserToData()
		{
			User savedUser = UserFileSystem.FindById(this.CurrentUser.Id);
			if (savedUser != null)
			{
				this.CurrentUser.score = savedUser.score;
			}
			else
			{
				UserFileSystem.Put(this.CurrentUser);
			}
		}
	}
}
