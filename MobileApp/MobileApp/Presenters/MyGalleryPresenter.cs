using MobileApp.Manager;
using MobileApp.Models;
using MobileApp.Views;
using Models.Cars;
using MobileApp.Services.WebAPI.Cars;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Presenters
{
    public class MyGalleryPresenter : BasePresenter
    {
        private IMyGalleryView view;
        private Page page;
        public ObservableCollection<CapturedCar> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private CapturedCarService service;

        public MyGalleryPresenter(MyGalleryPage page)
        {
            this.page = page;
            view = page;
            service = new CapturedCarService();
            Items = new ObservableCollection<CapturedCar>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            Initialize();
        }

        private void Initialize()
        {
            view.OnItem += new EventHandler<SelectedItemChangedEventArgs>(ItemClicked);
            view.Search += new EventHandler<EventArgs>(Search);
        }

        async Task ExecuteLoadItemsCommand()
        {
            lock (loadLock)
            {
                try
                {
                    GetAll();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        private async void GetAll()
        {
            Items.Clear();
            var items = await service.GetAll();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        async void ItemClicked(object sender, SelectedItemChangedEventArgs args)
        {
            CapturedCar item = args.SelectedItem as CapturedCar;
            if (item == null)
                return;

            await NavigationManager.GetInstance().NavigateToMyGalleryItem(page, new CarDetailModel(item));

            // Manually deselect item.
            view.ListView.SelectedItem = null;
        }

        void Search(object sender, EventArgs e)
        {
            LoadItemsCommand.Execute(null);
        }
    }
}