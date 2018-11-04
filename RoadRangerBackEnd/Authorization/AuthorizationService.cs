﻿using RoadRangerBackEnd.Users;
using RoadRangerBackEnd.Data;

namespace RoadRangerBackEnd.Authorization
{
	public class AuthorizationService
	{
		private static AuthorizationService instance;
		private User currentUser;
		private UserFileSystem userFileSystem = UserFileSystem.GetInstance();
		private AuthorizationService() { }

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
			return this.currentUser;
		}

		public User Login() {
			 return currentUser = new User(0, "username", "password", "name", 0);
		}

		public void SyncCurrentUserToData()
		{
			User savedUser = userFileSystem.FindById(this.currentUser.Id);
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