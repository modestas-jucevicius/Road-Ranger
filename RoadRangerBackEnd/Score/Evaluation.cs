﻿using RoadRangerBackEnd.Users;
using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Authorization;

namespace RoadRangerBackEnd.Score
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


        public int Evaluate(Car car)                     // Įvertinti automobilį taškais
        {
			User user = authorizationService.GetCurrentUser().Result;
			if (car.Status.Equals(CarStatus.NOT_STOLEN))
            {
				return user.Boosts.ScoreBoost(notStolenScore);
            }

            if (car.Status.Equals(CarStatus.STOLEN))
            {
				return user.Boosts.ScoreBoost(stolenScore);            }

            if (car.Status.Equals(CarStatus.STOLEN_PLATE))
            {
				return user.Boosts.ScoreBoost(stolenPlateScore);
            }

            if (car.Status.Equals(CarStatus.UNKNOWN))
            {
				return user.Boosts.ScoreBoost(unknownScore);
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
