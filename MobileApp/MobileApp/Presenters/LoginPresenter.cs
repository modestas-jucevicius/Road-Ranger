using System;
using System.Net;
using System.Net.Http;
using MobileApp.Manager;
using MobileApp.Views;
using Services.Authorization;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileApp.Presenters
{
    class LoginPresenter : BasePresenter
    {
		private ILoginView view;
        private Page page;
		private AuthorizationService authorization = AuthorizationService.GetInstance();

        public LoginPresenter(LoginPage page)
		{
            this.page = page;
            view = page;
            Initialize();
		}

		private void Initialize()
		{
			view.OnRegister += new EventHandler<RegisterEventArgs>(Register);
			view.OnLogin += new EventHandler<LoginEventArgs>(Login);
		}

		private async void Register(object sender, RegisterEventArgs args)
		{
            try
            {
                string token = await authorization.Register(view.Username, view.Password);
                await SecureStorage.SetAsync("authToken", token);
                await NavigationManager.GetInstance().NavigateBack(page);
            }
            catch (WebException)
            {
                await DialogAlertManager.GetInstance().ShowInternalDialogAlert(page);
            }
            catch (HttpRequestException)
            {
                await DialogAlertManager.GetInstance().ShowInternalDialogAlert(page);
            }
        }

		private async void Login(object sender, LoginEventArgs args)
		{
            try
            {
                string token = await authorization.Login(view.Username, view.Password);
                await SecureStorage.SetAsync("authToken", token);
                await NavigationManager.GetInstance().NavigateBack(page);
            }
            catch (WebException)
            {
                await DialogAlertManager.GetInstance().ShowInternalDialogAlert(page);
            }
            catch (HttpRequestException)
            {
                await DialogAlertManager.GetInstance().ShowInternalDialogAlert(page);
            }
        }
	}
}
