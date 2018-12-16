using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Repository.Models;
using WebAPI.Repository.DTO;

namespace WebAPI.Controllers
{
	[Authorize]
	[Controller]
	[Route("api/user")]
	public class UserController : ControllerBase
    {
		private readonly Interfaces.IAuthorizationService authorizationService;
        private readonly UserContext _userContext;

		public UserController(Interfaces.IAuthorizationService authorizationService, UserContext context)
		{
			this.authorizationService = authorizationService;
            this._userContext = context;
		}

		// POST: User aka Register (Create)
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Register([FromBody] UserDTO incomingUser)
		{
			try
			{
                User user = await _userContext.Users.FirstOrDefaultAsync(o => o.Username == incomingUser.Username);
				if (user != null)
				{
					return BadRequest("User already registered");
				}

				user = authorizationService.Register(incomingUser.Username, incomingUser.Password);
                _userContext.Add(user);
                await _userContext.SaveChangesAsync();
				string token = await authorizationService.Authenticate(incomingUser.Username, incomingUser.Password);
				return Ok(token);
			}
			catch (Exception)
			{
                return BadRequest("Could not create object");
			}
		}

		// GET: User
		[HttpGet]
		public async Task<IActionResult> Read()
		{
            var identity = HttpContext.User.Identity as ClaimsIdentity; //Gets Information from Token
            string ID = identity.FindFirst(ClaimTypes.Name).Value; //Takes Token field "Name" value
            User user = await _userContext.Users.FirstOrDefaultAsync(o => o.ID == ID);
            user = StripUserRead(user);
            return Ok(user);
		}

		// PUT: User
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] User user)
		{
			try
			{
				if (user == null)
				{
					return BadRequest("Object is not Valid");
				}

				var identity = HttpContext.User.Identity as ClaimsIdentity; //Gets Information from Token
				user.ID = identity.FindFirst(ClaimTypes.Name).Value; //Takes Token field "Name" value and fills it into request user so you couldn't modify other users
                User existingUser = await _userContext.Users.FirstOrDefaultAsync(o => o.ID == user.ID);
				if (existingUser == null)
				{
					return NotFound("User not found");
				}

				StripUserUpdate(existingUser, user);
				if (TryValidateModel(existingUser))
				{
					return BadRequest("Object is not Valid");
				}

                _userContext.SaveChanges();
			}
			catch (Exception)
			{
				return BadRequest("Could not update object");
			}
			return NoContent();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete()
		{
			try
			{
				var identity = HttpContext.User.Identity as ClaimsIdentity; //Gets Information from Token
				string id = identity.FindFirst(ClaimTypes.Name).Value; //Takes Token field "Name" value
				var item = await _userContext.FindAsync<User>(id);
				if (item == null)
				{
					return NotFound("User not found");
				}
                _userContext.Users.Remove(item);
                await _userContext.SaveChangesAsync();
			}
			catch (Exception)
			{
				return BadRequest("Object could not been deleted");
			}
			return NoContent();
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UserDTO incomingUser)
		{
			string token = await authorizationService.Authenticate(incomingUser.Username, incomingUser.Password);
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

		private void StripUserUpdate(User currentUser, User modifiedUser) //function to make sure some fields aren't touched by client
		{
            currentUser.Username = modifiedUser.Username;
            currentUser.Score = modifiedUser.Score;
            currentUser.BoostType = modifiedUser.BoostType;
		}
	}
}