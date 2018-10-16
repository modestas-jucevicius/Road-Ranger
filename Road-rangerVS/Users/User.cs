using Road_rangerVS.OutsideAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.Users
{
    class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        private int score = 0;

        public int getScore()
        {
            return score;
        }
        


        public void IncreaseScore(int evaluation)
        {
            this.score += evaluation;
        }
    }
}
