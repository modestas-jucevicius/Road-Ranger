using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Authorization;
using Road_rangerVS.Users;
using Road_rangerVS.Data;


namespace RoadRangerTest
{
	[TestClass]
	public class AuthorizationServiceTest
	{
		private AuthorizationService authorizationService = AuthorizationService.GetInstance();

		[TestMethod]
		public void GetCurrentUser_NoUser_null()
		{
			User result = authorizationService.GetCurrentUser();

			Assert.AreEqual(null, result);
		}

		[TestMethod]
		public void Login_Always_ChangesCurrentUser() //because of mock it's same as getUser
		{
			authorizationService.Login();

			User expected = authorizationService.GetCurrentUser();

			Assert.AreEqual(0, expected.Id);
			Assert.AreEqual("name", expected.Name);
			Assert.AreEqual("password", expected.Password);
			Assert.AreEqual(0, expected.score);
		}

		[TestMethod]
		public void GetCurrentUser_User_User()
		{
			User result = authorizationService.GetCurrentUser();

			Assert.AreEqual(0, result.Id);
			Assert.AreEqual("name", result.Name);
			Assert.AreEqual("password", result.Password);
			Assert.AreEqual(0, result.score);
		}
	}
}
