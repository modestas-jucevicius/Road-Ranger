using RoadRangerBackEnd.Authorization;
using RoadRangerBackEnd.Score;
using RoadRangerBackEnd.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadRangerMobileApp.ViewModels
{
    public class MyShopViewModel
    {
        //private readonly AuthorizationService authorization;
        private readonly MemoryRepository memoryRepository = MemoryRepository.GetInstance();
        private readonly BoostShop boostShop = BoostShop.GetInstance();

        public MyShopViewModel()
        {
            //this.authorization = AuthorizationService.GetInstance();
        }

        public void BuyBoost30p()
        {
            //int operationStatus = BoostShop.BuyBoost30p(authorization.GetCurrentUser());
            try
            {
                BoostShop.BuyBoost30p(MemoryRepository.users[0]);
            }
            catch (NotEnoughScorePointsException e)
            {

                //TODO: Do something when not enough points to buy score
            }
        }

        public void BuyBoost50p()
        {
            //int operationStatus = BoostShop.BuyBoost50p(authorization.GetCurrentUser());
            try
            {
                BoostShop.BuyBoost50p(MemoryRepository.users[0]);
            }
            catch (NotEnoughScorePointsException e)
            {
                //TODO: Do something when not enough points to buy score
            }
        }

        public void BuyBoostDouble()
        {
            //int operationStatus = BoostShop.BuyBoostDouble(authorization.GetCurrentUser());
            try
            {
                BoostShop.BuyBoostDouble(MemoryRepository.users[0]);
            }
            catch(NotEnoughScorePointsException e)
            {
                //TODO: Do something when not enough points to buy score
            }
        }
    }
}
