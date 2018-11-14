using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadRangerBackEnd.Data;
using RoadRangerBackEnd.Score;
using RoadRangerBackEnd.Users;

namespace RoadRangerTest
{
    [TestClass]
    public class HighscoresTest
    {
        /*[TestMethod]
        public void TestSortedByScore()
        {
            Highscores highscores = Highscores.GetInstance();
            UserFileSystem fileSystem = UserFileSystem.GetInstance();
            List<User> topUsers = highscores.SortedByScore(fileSystem.GetAll());
        
            User prevUser = topUsers[0];
            foreach (User user in topUsers){
                Assert.IsFalse(prevUser.Score < user.Score);
                prevUser = user;
            }
        }

        [TestMethod]
        public void TestTop10()
        {
            Highscores highscores = Highscores.GetInstance();
            UserFileSystem fileSystem = UserFileSystem.GetInstance();
            List<User> topUsers = highscores.SortedByScore(fileSystem.GetAll());
            List<User> top10 = highscores.Top10(topUsers);
            User prevUser = top10[0];
            foreach (User user in top10)
            {
                Assert.IsFalse(prevUser.Score < user.Score);
                prevUser = user;
            }
            Assert.IsFalse(!(top10.Count == 10));
        }

        [TestMethod]
        public void TestgetUsersPosition()
        {
            Highscores highscores = Highscores.GetInstance();
            UserFileSystem fileSystem = UserFileSystem.GetInstance();
            List<User> topUsers = highscores.SortedByScore(fileSystem.GetAll());
            User user = topUsers[4];
            int position = highscores.GetUsersPosition(topUsers, user);
            Assert.IsFalse(!(position == 5));
        }*/
    }
}
