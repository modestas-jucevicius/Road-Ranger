using RoadRangerBackEnd.Users;
using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Authorization;

namespace RoadRangerBackEnd.Score
{
    public class Evaluation
    {
        public static readonly int notStolenScore = 10;         // Taškai gaunami už nevogto automobilio atradimą
        public static readonly int stolenScore = 2500;          // Taškai gaunami už   vogto automobilio atradimą
        public static readonly int stolenPlateScore = 1500;     // Taškai gaunami už pavogtų numerių atradimą
        public static readonly int unknownScore = 0;            // Taškai gaunami už nežinomo statuso automobilio atradimą
        private AuthorizationService authorizationService = AuthorizationService.GetInstance();

        public int Evaluate(Car car)                     // Įvertinti automobilį taškais
        {
            if (car.Status.Equals(CarStatus.NOT_STOLEN))
            {
                return authorizationService.GetCurrentUser().boosts.ScoreBoost(notStolenScore);
            }

            if (car.Status.Equals(CarStatus.STOLEN))
            {
                return authorizationService.GetCurrentUser().boosts.ScoreBoost(stolenScore);
            }

            if (car.Status.Equals(CarStatus.STOLEN_PLATE))
            {
                return authorizationService.GetCurrentUser().boosts.ScoreBoost(stolenPlateScore);
            }

            if (car.Status.Equals(CarStatus.UNKNOWN))
            {
                return authorizationService.GetCurrentUser().boosts.ScoreBoost(unknownScore);
            }
            return 0;
        }

        public int IncreaseScore(User user, Car car)     //Padidina vartotojo bendrą įvertinimą
        {
            user.IncreaseScore(this.Evaluate(car));
            return 1;
        }
    }
}
