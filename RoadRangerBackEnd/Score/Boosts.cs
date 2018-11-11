using System;
using System.Collections.Generic;
using System.Text;

namespace RoadRangerBackEnd.Score
{
    public class Boosts
    {
        public Boolean boost30p = false;
        public Boolean boost50p = false;
        public Boolean boostDouble = false;

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
