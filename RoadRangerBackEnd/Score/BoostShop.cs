using RoadRangerBackEnd.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadRangerBackEnd.Score
{
    public class BoostShop
    {
        public static readonly int boost30pPrice = 10000;
        public static readonly int boost50pPrice = 25000;
        public static readonly int boostDoublePrice = 50000;

        private static BoostShop instance;
        private static readonly object padlock = new object();

        private BoostShop() { }

        public static BoostShop GetInstance() // jei jau yra toks objektas ji grazina, jei ne sukuria
        {
            lock (padlock)
            {
                if(instance == null)
                {
                    instance = new BoostShop();
                }
                return instance;
             }
        }

        public static void BuyBoost30p(User user)
        {
            if (user.boosts.boost30p)
            {
                //Boostas jau galioja
            }
            if (user.score >= boost30pPrice)
            {
                user.score -= boost30pPrice;
                user.boosts.boost30p = true;
            }
            else
            {
                throw new NotEnoughScorePointsException("Not enough score points to buy this boost");
            }
        }

        public static void BuyBoost50p(User user)
        {
            if (user.boosts.boost50p)
            {
                //Boostas jau galioja
            }
            if (user.score >= boost50pPrice)
            {
                user.score -= boost50pPrice;
                user.boosts.boost50p = true;
            }
            else
            {
                throw new NotEnoughScorePointsException("Not enough score points to buy this boost");
            }
        }

        public static void BuyBoostDouble(User user)
        {
            if (user.boosts.boostDouble)
            {
                //Boostas jau galioja
            }
            if (user.score >= boostDoublePrice)
            {
                user.score -= boostDoublePrice;
                user.boosts.boostDouble = true;
            }
            else
            {
                throw new NotEnoughScorePointsException("Not enough score points to buy this boost");
            }
        }
    }
}
