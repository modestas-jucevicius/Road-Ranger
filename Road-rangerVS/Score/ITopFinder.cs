using Road_rangerVS.Users;
using System.Collections.Generic;

namespace Road_rangerVS.Score
{
    interface ITopFinder
    {
        List<User> Top10(List<User> users);
        List<User> SortedByScore(List<User> users);
        int getUsersPosition(List<User> users, User user);
    }
}
