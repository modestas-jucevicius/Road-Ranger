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
<<<<<<< HEAD:RoadRangerMobileApp/RoadRangerMobileApp/ViewModels/MyShopViewModel.cs
        private readonly BoostShopService BoostShop = BoostShopService.GetInstance();
		private readonly AuthorizationService authorization = AuthorizationService.GetInstance();
=======
        private readonly BoostShopService boostShop = BoostShopService.GetInstance();
        private IShopView view;
>>>>>>> develop:RoadRangerMobileApp/RoadRangerMobileApp/Presenters/ShopPresenter.cs

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

<<<<<<< HEAD:RoadRangerMobileApp/RoadRangerMobileApp/ViewModels/MyShopViewModel.cs
        public async void BuyBoost30p()
=======
        public void BuyBoost30p(object sender, EventArgs e)
>>>>>>> develop:RoadRangerMobileApp/RoadRangerMobileApp/Presenters/ShopPresenter.cs
        {
            //int operationStatus = BoostShop.BuyBoost30p(authorization.GetCurrentUser());
            try
            {
				BoostShop.BuyBoost30p(await authorization.GetCurrentUser());
            }
            catch (NotEnoughScorePointsException exception)
            {
                Debug.WriteLine(exception.Message);
                //TODO: Do something when not enough points to buy score (Platform specific)
            }
        }

<<<<<<< HEAD:RoadRangerMobileApp/RoadRangerMobileApp/ViewModels/MyShopViewModel.cs
        public async void BuyBoost50p()
=======
        public void BuyBoost50p(object sender, EventArgs e)
>>>>>>> develop:RoadRangerMobileApp/RoadRangerMobileApp/Presenters/ShopPresenter.cs
        {
            //int operationStatus = BoostShop.BuyBoost50p(authorization.GetCurrentUser());
            try
            {
<<<<<<< HEAD:RoadRangerMobileApp/RoadRangerMobileApp/ViewModels/MyShopViewModel.cs
				BoostShop.BuyBoost50p(await authorization.GetCurrentUser());
			}
			catch (NotEnoughScorePointsException e)
=======
                BoostShopService.BuyBoost50p(MemoryRepository.users[0]);
            }
            catch (NotEnoughScorePointsException exception)
>>>>>>> develop:RoadRangerMobileApp/RoadRangerMobileApp/Presenters/ShopPresenter.cs
            {
                Debug.WriteLine(exception.Message);
                //TODO: Do something when not enough points to buy score (Platform specific)
            }
        }

<<<<<<< HEAD:RoadRangerMobileApp/RoadRangerMobileApp/ViewModels/MyShopViewModel.cs
        public async void BuyBoostDouble()
=======
        public void BuyBoostDouble(object sender, EventArgs e)
>>>>>>> develop:RoadRangerMobileApp/RoadRangerMobileApp/Presenters/ShopPresenter.cs
        {
            //int operationStatus = BoostShop.BuyBoostDouble(authorization.GetCurrentUser());
            try
            {
<<<<<<< HEAD:RoadRangerMobileApp/RoadRangerMobileApp/ViewModels/MyShopViewModel.cs
				BoostShop.BuyBoostDouble(await authorization.GetCurrentUser());
			}
			catch (NotEnoughScorePointsException e)
=======
                BoostShopService.BuyBoostDouble(MemoryRepository.users[0]);
            }
            catch (NotEnoughScorePointsException exception)
>>>>>>> develop:RoadRangerMobileApp/RoadRangerMobileApp/Presenters/ShopPresenter.cs
            {
                Debug.WriteLine(exception.Message);
                //TODO: Do something when not enough points to buy score (Platform specific)
            }
        }
    }
}
