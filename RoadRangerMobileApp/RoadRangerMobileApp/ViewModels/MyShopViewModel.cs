using RoadRangerBackEnd.Authorization;
using RoadRangerBackEnd.Score;
using RoadRangerBackEnd.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using RoadRangerMobileApp.Views;
using System.Diagnostics;

namespace RoadRangerMobileApp.ViewModels
{
    public class MyShopViewModel
    {
        //private readonly AuthorizationService authorization;
        private readonly MemoryRepository memoryRepository = MemoryRepository.GetInstance();
        private readonly BoostShopService boostShop = BoostShopService.GetInstance();

        public MyShopViewModel()
        {
            //this.authorization = AuthorizationService.GetInstance();
        }

        public void BuyBoost30p()
        {
            //int operationStatus = BoostShop.BuyBoost30p(authorization.GetCurrentUser());
            try
            {
                BoostShopService.BuyBoost30p(MemoryRepository.users[0]);
            }
            catch (NotEnoughScorePointsException e)
            {
                Debug.WriteLine(e.Message);
                //TODO: Do something when not enough points to buy score (Platform specific)
            }
        }

        public void BuyBoost50p()
        {
            //int operationStatus = BoostShop.BuyBoost50p(authorization.GetCurrentUser());
            try
            {
                BoostShopService.BuyBoost50p(MemoryRepository.users[0]);
            }
            catch (NotEnoughScorePointsException e)
            {
                Debug.WriteLine(e.Message);
                //TODO: Do something when not enough points to buy score (Platform specific)
            }
        }

        public void BuyBoostDouble()
        {
            //int operationStatus = BoostShop.BuyBoostDouble(authorization.GetCurrentUser());
            try
            {
                BoostShopService.BuyBoostDouble(MemoryRepository.users[0]);
            }
            catch(NotEnoughScorePointsException e)
            {
                Debug.WriteLine(e.Message);
                //TODO: Do something when not enough points to buy score (Platform specific)
            }
        }
    }
}
