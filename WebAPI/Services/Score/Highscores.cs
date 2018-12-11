using Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Services.Score
{
    public class Highscores : ITopFinder
    {
        private static Highscores instance;
        //private UserFileSystem fileSystem = UserFileSystem.GetInstance();
        private Highscores() { }                    // padaro, kad nebutu galima sukurti 
                                                    // objekto ne per metoda
        public static Highscores GetInstance()
        {
            if(instance == null)
            {
                return instance = new Highscores();
            }
            else
            {
                return instance;
            }
        }

        public List<User> SortedByScore(List<User> users) //Isrykiuoja User lista pagal scora mazejimo tvarka
        {
            return users.OrderByDescending(o=>o.Score).ToList();
        }

        public List<User> GetTops(List<User> users)
        {
            List<User> sortedUsers = SortedByScore(users);
            return sortedUsers.GetRange(0, 10);
        }

        public int GetUsersPosition(List<User> users, User user)
        {
            return users.IndexOf(user) + 1;
        }
    }
}
