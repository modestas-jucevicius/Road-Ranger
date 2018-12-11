using Models.Cars;
using Models.Users;

namespace WebAPI.Services.Score
{
    public class Evaluation
    {
        private static readonly int notStolenScore = 10;         // Taškai gaunami už nevogto automobilio atradimą
        private static readonly int stolenScore = 2500;          // Taškai gaunami už   vogto automobilio atradimą
        private static readonly int stolenPlateScore = 1500;     // Taškai gaunami už pavogtų numerių atradimą
        private static readonly int unknownScore = 0;            // Taškai gaunami už nežinomo statuso automobilio atradimą
        private static Evaluation instance = null;
        private static readonly object padlock = new object();

        public static Evaluation Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Evaluation();
                    }
                    return instance;
                }
            }
        }

        public int Evaluate(User user, CarStatus status)                   
        {
			if (status.Equals(CarStatus.NOT_STOLEN))
            {
                return BoostScoreFactory.GetScore(user.BoostType, notStolenScore);
            }

            if (status.Equals(CarStatus.STOLEN))
            {
                return BoostScoreFactory.GetScore(user.BoostType, stolenScore);
            }

            if (status.Equals(CarStatus.STOLEN_PLATE))
            {
				return BoostScoreFactory.GetScore(user.BoostType, stolenPlateScore);
            }

            if (status.Equals(CarStatus.UNKNOWN))
            {
				return BoostScoreFactory.GetScore(user.BoostType, unknownScore);
            }
            return 0;
        }
    }
}
