using MobileApp.Manager;
using MobileApp.Views;
using Models.Users;
using MobileApp.Services.WebAPI.Authorization;
using MobileApp.Services.WebAPI.Score;
using System;
using System.Threading.Tasks;

namespace MobileApp.Presenters
{
    public class ShopPresenter
    {
        private readonly ScoreService score;
        private readonly AuthorizationService authorization;
        private readonly IShopView view;

        public ShopPresenter(IShopView view)
        {
            this.view = view;
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
            view.IsPressable = false;
            try
            {
                User user = await authorization.GetCurrentUser();
                switch (await score.Boost30p(user))
                {
                    case 0:
                        authorization.UpdateUser(user);
                        break;
                    case 1:
                        await DialogAlertManager.ShowNotEnoughScoreDialogAlert(view.Page);
                        break;
                    default:
                        await DialogAlertManager.ShowInternalDialogAlert(view.Page);
                        break;
                }
            }
            catch
            {
                await DialogAlertManager.ShowInternalDialogAlert(view.Page);
            }
            view.IsPressable = true;
        }

        public async void BuyBoost50p(object sender, EventArgs e)
        {
            view.IsPressable = false;
            try
            {
                User user = await authorization.GetCurrentUser();
                switch (await score.Boost50p(user))
                {
                    case 0:
                        authorization.UpdateUser(user);
                        break;
                    case 1:
                        await DialogAlertManager.ShowNotEnoughScoreDialogAlert(view.Page);
                        break;
                    default:
                        await DialogAlertManager.ShowInternalDialogAlert(view.Page);
                        break;
                }
            }
            catch
            {
                await DialogAlertManager.ShowInternalDialogAlert(view.Page);
            }
            view.IsPressable = true;
        }

        public async void BuyBoostDouble(object sender, EventArgs e)
        {
            view.IsPressable = false;
            try
            {
                User user = await authorization.GetCurrentUser();
                switch (await score.BoostDouble(user))
                {
                    case 0:
                        authorization.UpdateUser(user);
                        break;
                    case 1:
                        await DialogAlertManager.ShowNotEnoughScoreDialogAlert(view.Page);
                        break;
                    default:
                        await DialogAlertManager.ShowInternalDialogAlert(view.Page);
                        break;
                }
            }
            catch
            {
                await DialogAlertManager.ShowInternalDialogAlert(view.Page);
            }
            view.IsPressable = true;
        }
    }
}
