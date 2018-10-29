using Road_rangerVS.Users;
using Road_rangerVS.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.OutsideAPI;
using Road_rangerVS.Cars;

namespace Road_rangerVS.Score
{
    public static class Evaluation
    {
        public static readonly int notStolenScore = 10;         // Taškai gaunami už nevogto automobilio atradimą
        public static readonly int stolenScore = 2500;          // Taškai gaunami už   vogto automobilio atradimą
        public static readonly int stolenPlateScore = 1500;     // Taškai gaunami už pavogtų numerių atradimą
        public static readonly int unknownScore = 0;            // Taškai gaunami už nežinomo statuso automobilio atradimą

        public static int Evaluate(Car car)                     // Įvertinti automobilį taškais
        {
            if (car.Status.Equals(CarStatus.NOT_STOLEN))
            {
                return notStolenScore;
            }

            if (car.Status.Equals(CarStatus.STOLEN))
            {
                return stolenScore;
            }

            if (car.Status.Equals(CarStatus.STOLEN_PLATE))
            {
                return stolenPlateScore;
            }

            if (car.Status.Equals(CarStatus.UNKNOWN))
            {
                return unknownScore;
            }
            return 0;
        }

        public static int IncreaseScore(User user, Car car)     //Padidina vartotojo bendrą įvertinimą
        {
            user.IncreaseScore(Evaluate(car));
            return 1;
        }
    }
}
