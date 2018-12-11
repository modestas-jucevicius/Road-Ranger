namespace WebAPI.Services.Score
{
    public class BoostScoreFactory
    {
        public static int GetScore(int boostType, int score)
        {
            if (boostType == 1)
            {
                score += (int)(score * 0.3);
            }
            if (boostType == 2)
            {
                score += (int)(score * 0.5);
            }
            if (boostType == 3)
            {
                score += score;
            }
            return score;
        }
    }
}
