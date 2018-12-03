using MobileApp.Manager;
using MobileApp.Views;
using Models.Users;
using Services.WebAPI.Authorization;
using Services.WebAPI.Score;
using System;
using Xamarin.Forms;

namespace MobileApp.Presenters
{
    public class ShopPresenter
    {
        private readonly ScoreService score;
        private readonly AuthorizationService authorization;
        private readonly IShopView view;
        private readonly Page page;

        public ShopPresenter(ShopPage page)
        {
            this.page = page;
            view = page;
            score = ScoreService.GetInstance();
            authorization = AuthorizationService.GetInstance();
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
            User user = await authorization.GetCurrentUser();
            switch (await score.Boost30p(user))
            {
                case 0:
                    authorization.UpdateUser(user);
                    return;
                case 1:
                    await DialogAlertManager.GetInstance().ShowNotEnoughScoreDialogAlert(page);
                    return;
                case 2:
                    await DialogAlertManager.GetInstance().ShowInternalDialogAlert(page);
                    return;
            }
        }

        public async void BuyBoost50p(object sender, EventArgs e)
        {
            User user = await authorization.GetCurrentUser();
            switch (await score.Boost50p(user))
            {
                case 0:
                    authorization.UpdateUser(user);
                    return;
                case 1:
                    await DialogAlertManager.GetInstance().ShowNotEnoughScoreDialogAlert(page);
                    return;
                case 2:
                    await DialogAlertManager.GetInstance().ShowInternalDialogAlert(page);
                    return;
            }
        }

        public async void BuyBoostDouble(object sender, EventArgs e)
        {
            User user = await authorization.GetCurrentUser();
            switch (await score.BoostDouble(user))
            {
                case 0:
                    authorization.UpdateUser(user);
                    return;
                case 1:
                    await DialogAlertManager.GetInstance().ShowNotEnoughScoreDialogAlert(page);
                    return;
                case 2:
                    await DialogAlertManager.GetInstance().ShowInternalDialogAlert(page);
                    return;
            }
        }
    }
}
