using System;
using System.Net.Http;
using MobileApp.Manager;
using MobileApp.Views;
using MobileApp.Services.WebAPI.Authorization;
using Xamarin.Essentials;
using MobileApp.Services.Validation;
using System.Threading.Tasks;

namespace MobileApp.Presenters
{
    class LoginPresenter : BasePresenter
    {
		private ILoginView view;
		private AuthorizationService authorization = AuthorizationService.GetInstance();
        private readonly UserValidator validator = new UserValidator();

        public LoginPresenter(ILoginView view)
		{
            this.view = view;
            Initialize();
		}

		private void Initialize()
		{
			view.OnRegister += new EventHandler<RegisterEventArgs>(Register);
			view.OnLogin += new EventHandler<LoginEventArgs>(Login);
		}

		private async void Register(object sender, RegisterEventArgs args)
		{
            view.IsPressable = false;
            if (validator.IsValid(view.Username, view.Password))
            {
                try
                {
                    await SignUp();
                }
                catch (HttpRequestException)
                {
                    await DialogAlertManager.ShowBadLoginOrPassword(view.Page);
                }
                catch (Exception)
                {
                    await DialogAlertManager.ShowInternalDialogAlert(view.Page);
                }
            }
            else
                await DialogAlertManager.ShowAuthentificationInputValidation(view.Page);
            view.IsPressable = true;
        }

		private async void Login(object sender, LoginEventArgs args)
		{
            view.IsPressable = false;
            if (validator.IsValid(view.Username, view.Password))
            {
                try
                {
                    await SignIn();
                }
                catch (HttpRequestException)
                {
                    await DialogAlertManager.ShowNotAvailableUsername(view.Page);
                }
                catch (Exception)
                {
                    await DialogAlertManager.ShowInternalDialogAlert(view.Page);
                }
            }
            else
                await DialogAlertManager.ShowAuthentificationInputValidation(view.Page);
            view.IsPressable = true;
        }

        private async Task SignUp()
        {
            string token = await authorization.Register(view.Username, view.Password);
            await SecureStorage.SetAsync("authToken", token);
            await DialogAlertManager.ShowRegistered(view.Page);
            NavigationManager.NavigateToMain(view.Page);
        }

        private async Task SignIn()
        {
            string token = await authorization.Login(view.Username, view.Password);
            await SecureStorage.SetAsync("authToken", token);
            await DialogAlertManager.ShowLoggedIn(view.Page);
            NavigationManager.NavigateToMain(view.Page);
        }
    }
}
