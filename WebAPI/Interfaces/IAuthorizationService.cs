using System.Threading.Tasks;
using WebAPI.Repository.Models;

namespace WebAPI.Interfaces
{
	public interface IAuthorizationService
	{
		Task<string> Authenticate(string username, string password);
		User Register(string username, string password);
	}
}
