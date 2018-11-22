using System;
using System.Collections.Generic;
using System.Text;
using RoadRangerMobileApp.Views;
using RoadRangerBackEnd.Authorization;
using Xamarin.Essentials;

namespace RoadRangerMobileApp.Presenters
{
    class LoginPresenter : BasePresenter
    {
		private ILoginView view;
		private AuthorizationService authorization = AuthorizationService.GetInstance();

		public LoginPresenter(ILoginView page)
		{
			this.view = page;
			this.Initialize();
		}

		private void Initialize()
		{
			this.view.OnRegister += new EventHandler<RegisterEventArgs>(Register);
			this.view.OnLogin += new EventHandler<LoginEventArgs>(Login);
		}

		private async void Register(object sender, RegisterEventArgs args)
		{
			string token = await authorization.Register(view.Username, view.Password);
			await SecureStorage.SetAsync("authToken", token);
			await view.NavigateBack();
		}

		private async void Login(object sender, LoginEventArgs args)
		{
			string token = await authorization.Login(view.Username, view.Password);
			await SecureStorage.SetAsync("authToken", token);
			await view.NavigateBack();
		}
	}
}
