using Models.Cars;
using Models.Users;
using Services.WebAPI.Authorization;

namespace WebAPIService.Score
{
    public class Evaluation
    {
        private static readonly int notStolenScore = 10;         // Taškai gaunami už nevogto automobilio atradimą
        private static readonly int stolenScore = 2500;          // Taškai gaunami už   vogto automobilio atradimą
        private static readonly int stolenPlateScore = 1500;     // Taškai gaunami už pavogtų numerių atradimą
        private static readonly int unknownScore = 0;            // Taškai gaunami už nežinomo statuso automobilio atradimą
        private static Evaluation instance = null;
        private static readonly object padlock = new object();
        private AuthorizationService authorizationService = AuthorizationService.GetInstance();

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
				return user.Boosts.ScoreBoost(notStolenScore);
            }

            if (status.Equals(CarStatus.STOLEN))
            {
				return user.Boosts.ScoreBoost(stolenScore);
            }

            if (status.Equals(CarStatus.STOLEN_PLATE))
            {
				return user.Boosts.ScoreBoost(stolenPlateScore);
            }

            if (status.Equals(CarStatus.UNKNOWN))
            {
				return user.Boosts.ScoreBoost(unknownScore);
            }
            return 0;
        }

        public int IncreaseScore(CarStatus status)    
        {
            User user = authorizationService.GetCurrentUser().Result;
            user.Score = user.Score + Evaluate(user, status);
            return 1;
        }
    }
}
