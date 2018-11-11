using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Search;
using RoadRangerMobileApp.ViewModels;
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
        private ICapturedCarFinder finder = new CapturedCarFinder();

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
            this.view.OnItem += new EventHandler<SelectedItemChangedEventArgs>(ClickOnItem);
            this.view.Search += new EventHandler<EventArgs>(Search);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                FindAll();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void FindAll()
        {
            Items.Clear();
            //var items = await DataStore.GetItemsAsync(true);
            var items = finder.FindAll();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        async void ClickOnItem(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as CapturedCar;
            if (item == null)
                return;

            await view.NavigateToCapturedCarDetailPage(item);

            // Manually deselect item.
            view.ListView.SelectedItem = null;
        }

        async void AddItem(object sender, EventArgs e)
        {
            await view.NavigateToAddStolenCarPage();
        }

        async void Search(object sender, EventArgs e)
        {
            LoadItemsCommand.Execute(null);
        }
    }
}
