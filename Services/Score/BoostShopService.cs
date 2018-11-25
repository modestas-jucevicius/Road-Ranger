using Models.Users;

namespace Services.Score
{
    public class BoostShopService
    {
        public static readonly int boost30pPrice = 10000;
        public static readonly int boost50pPrice = 25000;
        public static readonly int boostDoublePrice = 50000;

        private static BoostShopService instance;
        private static readonly object padlock = new object();

        private BoostShopService() { }

        public static BoostShopService GetInstance() // jei jau yra toks objektas ji grazina, jei ne sukuria
        {
            lock (padlock)
            {
                if(instance == null)
                {
                    instance = new BoostShopService();
                }
                return instance;
             }
        }

        public void BuyBoost30p(User user)
        {
            if (user.Boosts.boost30p)
            {
                //Boostas jau galioja
            }
            if (user.Score >= boost30pPrice)
            {
                user.Score -= boost30pPrice;
                user.Boosts.boost30p = true;
            }
            else
            {
                throw new NotEnoughScorePointsException("Not enough score points to buy this boost");
            }
        }

        public void BuyBoost50p(User user)
        {
            if (user.Boosts.boost50p)
            {
                //Boostas jau galioja
            }
            if (user.Score >= boost50pPrice)
            {
                user.Score -= boost50pPrice;
                user.Boosts.boost50p = true;
            }
            else
            {
                throw new NotEnoughScorePointsException("Not enough score points to buy this boost");
            }
        }

        public void BuyBoostDouble(User user)
        {
            if (user.Boosts.boostDouble)
            {
                //Boostas jau galioja
            }
            if (user.Score >= boostDoublePrice)
            {
                user.Score -= boostDoublePrice;
                user.Boosts.boostDouble = true;
            }
            else
            {
                throw new NotEnoughScorePointsException("Not enough score points to buy this boost");
            }
        }
    }
}
