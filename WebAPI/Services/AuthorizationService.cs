using System;
using WebAPI.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using WebAPI.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
	public class AuthorizationService : IAuthorizationService
	{
		private readonly UserContext _userContext;
		private readonly byte[] secret = Encoding.ASCII.GetBytes("6686639a69fa018ce8419e97f1235eb6");

		public AuthorizationService(UserContext context)
		{
			this._userContext = context;
		}

		public async Task<string> Authenticate(string username, string password)
		{

            User user = await _userContext.Users.FirstOrDefaultAsync(o => o.Username == username);

            // return null if user not found
            if (user == null)
			{
				return null;
			}

			string hash = Hash(password, user.Salt);

			if (user.Password != hash)
			{
				return null;
			}
			// authentication successful so generate jwt token
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.ID.ToString())
				}),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

        public Models.User Register(string username, string password)
		{
            Models.User user = new Models.User()
			{
				ID = Guid.NewGuid().ToString(),
				Username = username,
				Salt = GenerateSalt(),
				Score = 0
			};
			user.Password = Hash(password, user.Salt);
			return user;
		}

		private string Hash(string password, string salt)
		{
			byte[] hash = KeyDerivation.Pbkdf2(password, Convert.FromBase64String(salt), KeyDerivationPrf.HMACSHA256, 10000, 256 / 8);
			return Convert.ToBase64String(hash);
		}

		private string GenerateSalt()
		{
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			byte[] buff = new byte[32];
			rng.GetBytes(buff);
			return Convert.ToBase64String(buff);
		}
    }
}
