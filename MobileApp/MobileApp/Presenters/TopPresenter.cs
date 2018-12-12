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
        private readonly Page page;
        private readonly ITopView view;
        public ObservableCollection<User> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private ScoreService service;
        private AuthorizationService authorization;

        public TopPresenter(TopPage page)
        {
            this.page = page;
            view = page;
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
            lock (loadLock)
            {
                try
                {
                    FindAll();
                }
                catch (Exception ex)
                {
                    ShowInternalDialogAlert();
                }
            }
        }

        private async void ShowInternalDialogAlert()
        {
            await DialogAlertManager.ShowInternalDialogAlert(page);
        }

        private async void FindAll()
        {
            Items.Clear();
            List<User> users = await service.GetTop();
            foreach (var item in users)
            {
                Items.Add(item);
            }
        }

        void Search(object sender, EventArgs e)
        {
            LoadItemsCommand.Execute(null);
        }
    }
}
