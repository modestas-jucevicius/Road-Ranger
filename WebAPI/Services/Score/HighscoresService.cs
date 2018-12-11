using Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Services.Score
{
    public class HighscoresService : ITopFinder
    {
        const int numberOfTops = 10;
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

        public List<User> GetTops(List<User> users)
        {
            List<User> sortedUsers = SortedByScore(users);
            if(sortedUsers.Count >= numberOfTops)
            {
                return sortedUsers.GetRange(0, numberOfTops);
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
