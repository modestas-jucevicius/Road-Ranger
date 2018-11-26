using MobileApp.Manager;
using MobileApp.Views;
using Models.Users;
using Services.Score;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WebService.Authorization;
using Xamarin.Forms;

namespace MobileApp.Presenters
{
    public class TopPresenter : BasePresenter
    {
        private readonly Page page;
        private readonly ITopView view;
        public ObservableCollection<User> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private HighscoresService highscores;
		private AuthorizationService authorization = AuthorizationService.GetInstance();

        public TopPresenter(TopPage page)
        {
            this.page = page;
            view = page;
            Items = new ObservableCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            highscores = HighscoresService.Instance;
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
            await DialogAlertManager.GetInstance().ShowInternalDialogAlert(page);
        }

        private async void FindAll()
        {
            Items.Clear();
            List<User> users = new List<User>();
            users.Add(await authorization.GetCurrentUser());

            users = highscores.GetTops(users);
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
