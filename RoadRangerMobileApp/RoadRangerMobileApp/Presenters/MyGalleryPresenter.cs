using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Data;
using RoadRangerMobileApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RoadRangerMobileApp.Presenters
{
    public class MyGalleryPresenter : BasePresenter
    {
        private IMyGalleryView view;
        public ObservableCollection<CapturedCar> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private CapturedCarService service = new CapturedCarService();

        public MyGalleryPresenter(IMyGalleryView page)
        {
            this.view = page;
            Items = new ObservableCollection<CapturedCar>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            this.Initialize();
        }

        private void Initialize()
        {
            this.view.Add += new EventHandler<EventArgs>(AddItem);
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
            //var items = await DataStore.GetItemsAsync(true);
            var items = service.FindAll();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        async void ItemClicked(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as CapturedCar;
            if (item == null)
                return;

            await view.NavigateToCarDetailPage(item);

            // Manually deselect item.
            view.ListView.SelectedItem = null;
        }

        async void AddItem(object sender, EventArgs e)
        {
            await view.NavigateToAddCarPage();
        }

        async void Search(object sender, EventArgs e)
        {
            LoadItemsCommand.Execute(null);
        }
    }
}
