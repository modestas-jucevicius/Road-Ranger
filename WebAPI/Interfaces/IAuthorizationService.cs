using WebAPI.Models;

namespace WebAPI.Interfaces
{
	public interface IAuthorizationService
	{
		string Authenticate(string username, string password);
		User Register(string username, string password);
	}
}
