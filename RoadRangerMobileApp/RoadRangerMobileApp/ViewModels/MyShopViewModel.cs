using RoadRangerBackEnd.Authorization;
using RoadRangerBackEnd.Score;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadRangerMobileApp.ViewModels
{
    public class MyShopViewModel : BaseViewModel
    {
        private readonly AuthorizationService authorization;

        public MyShopViewModel()
        {
            this.authorization = AuthorizationService.GetInstance();
        }

        public void BuyBoost30p()
        {
            int operationStatus = BoostShop.BuyBoost30p(authorization.GetCurrentUser());
            if (operationStatus == 1)
            {
                //Boostas jau galioja
            }
            if (operationStatus == 2)
            {
                //Nepakanka scoro nusipirkti boostui
            }
            else
            {
                //Operacija sekminga
            }
        }

        public void BuyBoost50p()
        {
            int operationStatus = BoostShop.BuyBoost50p(authorization.GetCurrentUser());
            if (operationStatus == 1)
            {
                //Boostas jau galioja
            }
            if (operationStatus == 2)
            {
                //Nepakanka scoro nusipirkti boostui
            }
            else
            {
                //Operacija sekminga
            }
        }

        public void BuyBoostDouble()
        {
            int operationStatus = BoostShop.BuyBoostDouble(authorization.GetCurrentUser());
            if (operationStatus == 1)
            {
                //Boostas jau galioja
            }
            if (operationStatus == 2)
            {
                //Nepakanka scoro nusipirkti boostui
            }
            else
            {
                //Operacija sekminga
            }
        }
    }
}
