using RoadRangerBackEnd.Data;
using RoadRangerBackEnd.Score;
using RoadRangerBackEnd.Users;
using RoadRangerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RoadRangerMobileApp.Presenters
{
    public class TopPresenter : BasePresenter
    {
        private ITopView view;
        public ObservableCollection<User> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private HighscoresService highscores;

        public TopPresenter(ITopView page)
        {
            this.view = page;
            Items = new ObservableCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            highscores = HighscoresService.Instance;
            this.Initialize();
        }

        public void Initialize()
        {
            this.view.Search += new EventHandler<EventArgs>(Search);
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
                    Debug.WriteLine(ex);
                }
            }
        }
        /*
         * Pakeisti, kai atsiras duombaze! (FindAll())
         */
        private void FindAll()
        {
            Items.Clear();
            MemoryRepository repository = MemoryRepository.GetInstance();
            List<User> users = MemoryRepository.users;
            users = highscores.GetTops(users);
            foreach (var item in users)
            {
                Items.Add(item);
            }
        }

        async void Search(object sender, EventArgs e)
        {
            LoadItemsCommand.Execute(null);
        }
    }
}
