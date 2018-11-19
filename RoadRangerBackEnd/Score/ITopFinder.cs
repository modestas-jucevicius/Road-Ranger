using RoadRangerBackEnd.Users;
using System.Collections.Generic;

namespace RoadRangerBackEnd.Score
{
    public interface ITopFinder
    {
        List<User> GetTops(List<User> users);
        List<User> SortedByScore(List<User> users);
        int GetUsersPosition(List<User> users, User user);
    }
}
