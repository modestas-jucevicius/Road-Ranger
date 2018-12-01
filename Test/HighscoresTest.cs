using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Users;
using Storage.Data.Users;

namespace Test
{
    [TestClass]
    public class HighscoresTest
    {
        [TestMethod]
        public void TestSortedByScore()
        {
            //HighscoresService highscores = HighscoresService.Instance;
            UserFileSystem fileSystem = UserFileSystem.GetInstance();
            /*var list = fileSystem.GetAll();
            List<User> topUsers = highscores.SortedByScore();
        
            User prevUser = topUsers[0];
            foreach (User user in topUsers){
                Assert.IsFalse(prevUser.Score < user.Score);
                prevUser = user;
            }
            */
        }

        [TestMethod]
        public void TestTop10()
        {
            //HighscoresService highscores = HighscoresService.Instance;
            UserFileSystem fileSystem = UserFileSystem.GetInstance();
            /*List<User> topUsers = highscores.SortedByScore(fileSystem.GetAll());
            List<User> top10 = highscores.GetTops(topUsers);
            User prevUser = top10[0];
            foreach (User user in top10)
            {
                Assert.IsFalse(prevUser.Score < user.Score);
                prevUser = user;
            }
            Assert.IsFalse(!(top10.Count == 10));
            */
        }

        [TestMethod]
        public void TestgetUsersPosition()
        {
            //HighscoresService highscores = HighscoresService.Instance;
            UserFileSystem fileSystem = UserFileSystem.GetInstance();
            /*List<User> topUsers = highscores.SortedByScore(fileSystem.GetAll());
            User user = topUsers[4];
            int position = highscores.GetUsersPosition(topUsers, user);
            Assert.IsFalse(!(position == 5));
            */
        }
    }
}
