using System.Collections.Generic;
using System.Linq;
using RoadRangerBackEnd.Data;
using RoadRangerBackEnd.Users;

namespace RoadRangerBackEnd.Score
{
    public class HighscoresService : ITopFinder
    {
        private static HighscoresService instance = null;
        private static readonly object padlock = new object();
        private HighscoresService() { }                    // padaro, kad nebutu galima sukurti 
                                                    // objekto ne per metoda
        public static HighscoresService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new HighscoresService();
                    }
                    return instance;
                }
            }
        }

        public List<User> SortedByScore(List<User> users) //Isrykiuoja User lista pagal scora mazejimo tvarka
        {
            return users.OrderByDescending(o=>o.Score).ToList();
        }

        public List<User> Top10(List<User> users)
        {
            List<User> sortedUsers = SortedByScore(users);
            if(sortedUsers.Count >= 10)
            {
                return sortedUsers.GetRange(0, 10);
            }
            else
            {
                return sortedUsers.GetRange(0, sortedUsers.Count);
            }
        }

        public int GetUsersPosition(List<User> users, User user)
        {
            return users.IndexOf(user) + 1;
        }
    }
}
