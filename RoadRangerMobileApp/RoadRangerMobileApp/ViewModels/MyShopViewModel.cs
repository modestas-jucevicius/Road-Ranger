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
        private readonly BoostShopService BoostShop = BoostShopService.GetInstance();
		private readonly AuthorizationService authorization = AuthorizationService.GetInstance();

        public MyShopViewModel()
        {
            //this.authorization = AuthorizationService.GetInstance();
        }

        public void messageCatcher()
        {
            MessagingCenter.Subscribe<ShopPage>(this, "Boost30p", (sender) => {
                
            });
        }

        public async void BuyBoost30p()
        {
            //int operationStatus = BoostShop.BuyBoost30p(authorization.GetCurrentUser());
            System.Console.WriteLine("Trying to buy the boost...");
            try
            {
				BoostShop.BuyBoost30p(await authorization.GetCurrentUser());
            }
            catch (NotEnoughScorePointsException e)
            {
                Debug.WriteLine(e.Message);
                //TODO: Do something when not enough points to buy score
            }
        }

        public async void BuyBoost50p()
        {
            //int operationStatus = BoostShop.BuyBoost50p(authorization.GetCurrentUser());
            try
            {
				BoostShop.BuyBoost50p(await authorization.GetCurrentUser());
			}
			catch (NotEnoughScorePointsException e)
            {
                Debug.WriteLine(e.Message);
                //TODO: Do something when not enough points to buy score
            }
        }

        public async void BuyBoostDouble()
        {
            //int operationStatus = BoostShop.BuyBoostDouble(authorization.GetCurrentUser());
            try
            {
				BoostShop.BuyBoostDouble(await authorization.GetCurrentUser());
			}
			catch (NotEnoughScorePointsException e)
            {
                Debug.WriteLine(e.Message);
                //TODO: Do something when not enough points to buy score
            }
        }
    }
}
