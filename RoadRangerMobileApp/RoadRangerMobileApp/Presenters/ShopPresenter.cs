using RoadRangerBackEnd.Data;
using RoadRangerBackEnd.Score;
using RoadRangerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RoadRangerMobileApp.Presenters
{
    public class ShopPresenter
    {
        private readonly MemoryRepository memoryRepository = MemoryRepository.GetInstance();
        private readonly BoostShopService boostShop = BoostShopService.GetInstance();
        private IShopView view;

        public ShopPresenter(IShopView view)
        {
            this.view = view;
            this.Initialize();
        }

        public void Initialize()
        {
            this.view.Boost30p += new EventHandler<EventArgs>(BuyBoost30p);
            this.view.Boost50p += new EventHandler<EventArgs>(BuyBoost50p);
            this.view.BoostDouble += new EventHandler<EventArgs>(BuyBoostDouble);
        }

        public void BuyBoost30p(object sender, EventArgs e)
        {
            //int operationStatus = BoostShop.BuyBoost30p(authorization.GetCurrentUser());
            try
            {
                BoostShopService.BuyBoost30p(MemoryRepository.users[0]);
            }
            catch (NotEnoughScorePointsException exception)
            {
                Debug.WriteLine(exception.Message);
                //TODO: Do something when not enough points to buy score (Platform specific)
            }
        }

        public void BuyBoost50p(object sender, EventArgs e)
        {
            //int operationStatus = BoostShop.BuyBoost50p(authorization.GetCurrentUser());
            try
            {
                BoostShopService.BuyBoost50p(MemoryRepository.users[0]);
            }
            catch (NotEnoughScorePointsException exception)
            {
                Debug.WriteLine(exception.Message);
                //TODO: Do something when not enough points to buy score (Platform specific)
            }
        }

        public void BuyBoostDouble(object sender, EventArgs e)
        {
            //int operationStatus = BoostShop.BuyBoostDouble(authorization.GetCurrentUser());
            try
            {
                BoostShopService.BuyBoostDouble(MemoryRepository.users[0]);
            }
            catch (NotEnoughScorePointsException exception)
            {
                Debug.WriteLine(exception.Message);
                //TODO: Do something when not enough points to buy score (Platform specific)
            }
        }
    }
}
