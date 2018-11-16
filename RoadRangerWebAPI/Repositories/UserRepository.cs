using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoadRangerWebAPI.Interfaces;
using RoadRangerWebAPI.Models;

namespace RoadRangerWebAPI.Repositories
{
	public class UserRepository : IUserRepository
	{
		private List<User> UserList;

		public UserRepository()
		{
			InitializeData();
		}

		public void Create(Object user)
		{
			UserList.Add((User) user);
		}

		public Object Read(string id)
		{
			User user = UserList.FirstOrDefault(foundUser => foundUser.ID == id);
			if (user != null)
			{
				return user.ShallowCopy();
			}

			return null;
		}

		public User ReadByUserName(string userName)
		{
			User user = UserList.FirstOrDefault(foundUser => foundUser.Username == userName);
			if (user != null)
			{
				return user.ShallowCopy();
			}

			return null;
		}

		public void Update(Object user)
		{
			User updateObject = (User) user;
			User currentObject = UserList.FirstOrDefault(foundUser => foundUser.ID == updateObject.ID);
			var index = UserList.IndexOf(currentObject);
			UserList.RemoveAt(index);
			UserList.Insert(index, updateObject);
		}

		public void Delete(string id)
		{
			UserList.Remove((User) this.Read(id));
		}

		private void InitializeData()
		{
			UserList = new List<User>();

			var user1 = new User
			{
				ID = Guid.NewGuid().ToString(),
				Username = "user1",
				Password = "HashedPassword",
				Score = 0
			};

			var user2 = new User
			{
				ID = Guid.NewGuid().ToString(),
				Username = "user2",
				Password = "HashedPassword",
				Score = 0
			};

			var user3 = new User
			{
				ID = Guid.NewGuid().ToString(),
				Username = "user3",
				Password = "HashedPassword",
				Score = 0
			};

			UserList.Add(user1);
			UserList.Add(user2);
			UserList.Add(user3);
		}
	}
}
