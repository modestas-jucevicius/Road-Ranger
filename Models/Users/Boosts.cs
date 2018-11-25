using System;

namespace Models.Users
{
    public class Boosts
    {
        public Boolean boost30p { get; set; } = false;
		public Boolean boost50p { get; set; } = false;
		public Boolean boostDouble { get; set; } = false;

        public int ScoreBoost(int score)
        {
            int boostedScore = score;
            if (boost30p)
            {
                boostedScore += (int)(score * 0.3);
            }
            if (boost50p)
            {
                boostedScore += (int)(score * 0.5);
            }
            if (boostDouble)
            {
                boostedScore += score;
            }
            return boostedScore;
        }
    }
}
