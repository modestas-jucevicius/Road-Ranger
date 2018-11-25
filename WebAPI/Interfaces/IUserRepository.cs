using WebAPI.Models;

namespace WebAPI.Interfaces
{
	public interface IUserRepository : ICrud
	{
		User ReadByUserName(string userName);
	}
}
