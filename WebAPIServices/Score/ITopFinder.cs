using Models.Users;
using System.Collections.Generic;

namespace WebAPIService.Score
{
    public interface ITopFinder
    {
        List<User> GetTops(List<User> users);
        List<User> SortedByScore(List<User> users);
        int GetUsersPosition(List<User> users, User user);
    }
}
