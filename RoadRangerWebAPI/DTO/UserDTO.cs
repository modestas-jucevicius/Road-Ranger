﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRangerWebAPI.DTO
{
	public class UserDTO
	{
		public string Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public int Score { get; set; }
	}
}
