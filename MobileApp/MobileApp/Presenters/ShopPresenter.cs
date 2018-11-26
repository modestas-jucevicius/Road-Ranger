using MobileApp.Manager;
using MobileApp.Views;
using Score;
using Services.Score;
using System;
using WebService.Authorization;
using Xamarin.Forms;

namespace MobileApp.Presenters
{
    public class ShopPresenter
    {
        //private readonly MemoryRepository memoryRepository = MemoryRepository.GetInstance();
        private readonly BoostShopService boostShop = BoostShopService.GetInstance();
		private readonly AuthorizationService authorization = AuthorizationService.GetInstance();
        private readonly IShopView view;
        private readonly Page page;

        public ShopPresenter(ShopPage page)
        {
            this.page = page;
            view = page;
            Initialize();
        }

        public void Initialize()
        {
            view.Boost30p += new EventHandler<EventArgs>(BuyBoost30pAsync);
            view.Boost50p += new EventHandler<EventArgs>(BuyBoost50p);
            view.BoostDouble += new EventHandler<EventArgs>(BuyBoostDouble);
        }

        public async void BuyBoost30pAsync(object sender, EventArgs e)
        {
            try
            {
                boostShop.BuyBoost30p(await authorization.GetCurrentUser());
            }
            catch (NotEnoughScorePointsException ex)
            {
                await DialogAlertManager.GetInstance().ShowNotEnoughScoreDialogAlert(page);
            }
            catch (Exception ex)
            {
                await DialogAlertManager.GetInstance().ShowInternalDialogAlert(page);
            }
        }

        public async void BuyBoost50p(object sender, EventArgs e)
        {
            try
            {
                boostShop.BuyBoost50p(await authorization.GetCurrentUser());
            }
            catch (NotEnoughScorePointsException ex)
            {
                await DialogAlertManager.GetInstance().ShowNotEnoughScoreDialogAlert(page);
            }
            catch (Exception ex)
            {
                await DialogAlertManager.GetInstance().ShowInternalDialogAlert(page);
            }
        }

        public async void BuyBoostDouble(object sender, EventArgs e)
        {
            try
            {
                boostShop.BuyBoostDouble(await authorization.GetCurrentUser());
            }
            catch (NotEnoughScorePointsException ex)
            {
                await DialogAlertManager.GetInstance().ShowNotEnoughScoreDialogAlert(page);
            }
            catch (Exception ex)
            {
                await DialogAlertManager.GetInstance().ShowInternalDialogAlert(page);
            }
        }
    }
}
