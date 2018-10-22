using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Users;
using Road_rangerVS.Data;

namespace Road_rangerVS.Authorization
{
	class AuthorizationService
	{
		private static AuthorizationService instance;
		private User currentUser;
		private UserFileSystem userFileSystem = UserFileSystem.GetInstance();
		private AuthorizationService() { }

		public static AuthorizationService getInstance()
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

		public User getCurrentUser()
		{
			return this.currentUser;
		}

		public User login() {
			 return currentUser = new User(0, "username", "password", "name", 0);
		}

		private void syncCurrentUserToData()
		{
			User savedUser = userFileSystem.FindById(this.currentUser.id);
			if (savedUser != null)
			{
				this.currentUser.score = savedUser.score;
			}
			else
			{
				userFileSystem.Put(this.currentUser);
			}
		}
	}
}
