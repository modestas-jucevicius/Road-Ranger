using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoadRangerWebAPI.Interfaces;
using RoadRangerWebAPI.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using RoadRangerWebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Diagnostics;
using RoadRangerWebAPI.DTO;

namespace RoadRangerWebAPI.Controllers
{
	[Authorize]
	[Controller]
	[Route("api/user")]
	public class UserController : ControllerBase
    {
		private readonly IUserRepository userRepository;
		private readonly RoadRangerWebAPI.Interfaces.IAuthorizationService authorizationService;

		public UserController(IUserRepository userRepository, RoadRangerWebAPI.Interfaces.IAuthorizationService authorizationService)
		{
			this.userRepository = userRepository;
			this.authorizationService = authorizationService;
		}

		// POST: User aka Register (Create)
		[AllowAnonymous]
		[HttpPost]
		public IActionResult Register([FromBody] UserDTO incomingUser)
		{
			try
			{
				User user = userRepository.ReadByUserName(incomingUser.Username);
				if (user != null)
				{
					return BadRequest("User already registered");
				}

				user = authorizationService.Register(incomingUser.Username, incomingUser.Password);
				userRepository.Create(user);
				string token = authorizationService.Authenticate(incomingUser.Username, incomingUser.Password);
				return Ok(token);
			}
			catch (Exception)
			{
				return BadRequest("Could not create object");
			}
		}

		// GET: User
		[HttpGet]
		public IActionResult Read()
		{
			var identity = HttpContext.User.Identity as ClaimsIdentity; //Gets Information from Token
			string ID = identity.FindFirst(ClaimTypes.Name).Value; //Takes Token field "Name" value
			User user = (User)userRepository.Read(ID);
			return Ok(StripUserRead(user));
		}

		// PUT: User
		[HttpPut]
		public IActionResult Update([FromBody] User user)
		{
			try
			{
				if (user == null)
				{
					return BadRequest("Object is not Valid");
				}

				var identity = HttpContext.User.Identity as ClaimsIdentity; //Gets Information from Token
				user.ID = identity.FindFirst(ClaimTypes.Name).Value; //Takes Token field "Name" value and fills it into request user so you couldn't modify other users
				User existingUser = (User) userRepository.Read(user.ID);
				if (existingUser == null)
				{
					return NotFound("User not found");
				}

				user = StripUserUpdate(user, existingUser);
				if (TryValidateModel(user))
				{
					return BadRequest("Object is not Valid");
				}
				
				userRepository.Update(user);
			}
			catch (Exception)
			{
				return BadRequest("Could not update object");
			}
			return NoContent();
		}

		[HttpDelete]
		public IActionResult Delete()
		{
			try
			{
				var identity = HttpContext.User.Identity as ClaimsIdentity; //Gets Information from Token
				string id = identity.FindFirst(ClaimTypes.Name).Value; //Takes Token field "Name" value
				var item = userRepository.Read(id);
				if (item == null)
				{
					return NotFound("User not found");
				}
				userRepository.Delete(id);
			}
			catch (Exception)
			{
				return BadRequest("Object could not been deleted");
			}
			return NoContent();
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public IActionResult Login([FromBody] UserDTO incomingUser)
		{
			string token = authorizationService.Authenticate(incomingUser.Username, incomingUser.Password);
			if (token == null)
			{
				return BadRequest(new { message = "Username or password is incorrect" });
			}

			return Ok(token);
		}

		private User StripUserRead(User user) //function to remove information which you shouldn't show client
		{
			user.Password = null;
			user.Salt = null;
			return user;
		}

		private User StripUserUpdate(User modifiedUser, User currentUser) //function to make sure some fields aren't touched by client
		{
			modifiedUser.Password = currentUser.Password;
			modifiedUser.Salt = currentUser.Salt;
			return modifiedUser;
		}
	}
}