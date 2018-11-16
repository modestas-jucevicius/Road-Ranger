using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoadRangerWebAPI.Models;

namespace RoadRangerWebAPI.Interfaces
{
	public interface IUserRepository : ICrud
	{
		User ReadByUserName(string userName);
	}
}
