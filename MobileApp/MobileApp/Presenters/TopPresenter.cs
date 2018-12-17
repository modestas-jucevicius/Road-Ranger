using MobileApp.Manager;
using MobileApp.Views;
using Models.Users;
using MobileApp.Services.WebAPI.Authorization;
using MobileApp.Services.WebAPI.Score;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Presenters
{
    public class TopPresenter : BasePresenter
    {
        private readonly ITopView view;
        public ObservableCollection<User> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private ScoreService service;
        private AuthorizationService authorization;

        public TopPresenter(ITopView view)
        {
            this.view = view;
            authorization = AuthorizationService.GetInstance();
            service = ScoreService.GetInstance();
            Items = new ObservableCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            Initialize();
        }

        public void Initialize()
        {
            view.Search += new EventHandler<EventArgs>(Search);
        }

        async Task ExecuteLoadItemsCommand()
        {
        }

        private async Task FindAll()
        {
            Items.Clear();
            var users = await service.GetTop();
            foreach (var item in users)
            {
                Items.Add(item);
            }
        }

        async void Search(object sender, EventArgs e)
        {
            view.IsPressable = false;
            try
            {
                await FindAll();
            }
            catch (Exception)
            {
                await DialogAlertManager.ShowInternalDialogAlert(view.Page);
                await NavigationManager.NavigateBack(view.Page);
            }
            LoadItemsCommand.Execute(null);
            view.IsPressable = true;
        }
    }
}
