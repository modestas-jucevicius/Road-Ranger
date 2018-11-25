using MobileApp.Manager;
using MobileApp.Models;
using MobileApp.Views;
using Models.Cars;
using Storage.Data;
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
        private CapturedCarService service = new CapturedCarService();
 
        public MyGalleryPresenter(MyGalleryPage page)
        {
            this.page = page;
            this.view = page;
            Items = new ObservableCollection<CapturedCar>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            this.Initialize();
        }

        private void Initialize()
        {
            this.view.OnItem += new EventHandler<SelectedItemChangedEventArgs>(ItemClicked);
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

        private void FindAll()
        {
            Items.Clear();
            var items = service.FindAll();
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
