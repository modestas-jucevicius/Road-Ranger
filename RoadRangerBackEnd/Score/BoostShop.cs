using RoadRangerBackEnd.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadRangerBackEnd.Score
{
    public static class BoostShop
    {
        public static readonly int boost30pPrice = 10000;
        public static readonly int boost50pPrice = 25000;
        public static readonly int boostDoublePrice = 50000;

        public static int BuyBoost30p(User user)
        {
            if (user.boosts.boost30p)
            {
                return 1;       //Boostas jau galioja
            }
            if (user.score >= boost30pPrice)
            {
                user.score -= boost30pPrice;
                user.boosts.boost30p = true;
                return 0;
            }
            else
            {
                return 2;       //Nepakanka score tasku boostui nusipirkti
            }
        }

        public static int BuyBoost50p(User user)
        {
            if (user.boosts.boost50p)
            {
                return 1;       //Boostas jau galioja
            }
            if (user.score >= boost50pPrice)
            {
                user.score -= boost50pPrice;
                user.boosts.boost50p = true;
                return 0;
            }
            else
            {
                return 2;       //Nepakanka score tasku boostui nusipirkti
            }
        }

        public static int BuyBoostDouble(User user)
        {
            if (user.boosts.boostDouble)
            {
                return 1;       //Boostas jau galioja
            }
            if (user.score >= boostDoublePrice)
            {
                user.score -= boostDoublePrice;
                user.boosts.boostDouble = true;
                return 0;
            }
            else
            {
                return 2;       //Nepakanka score tasku boostui nusipirkti
            }
        }
    }
}
