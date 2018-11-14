using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoadRangerWebAPI.Models;

namespace RoadRangerWebAPI.Interfaces
{
	public interface IAuthorizationService
	{
		string Authenticate(string username, string password);
		User Register(string username, string password);
	}
}
