using MobileApp.Manager;
using MobileApp.Models;
using MobileApp.Views;
using Models.Cars;
using Services.Validation;
using Storage.Data;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Presenters
{
    public class SearchPresenter : BasePresenter
    {
        private ISearchView view;
        private Page page;
        public ObservableCollection<CapturedCar> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private CapturedCarService service = new CapturedCarService();

        public SearchPresenter(SearchPage page)
        {
            this.page = page;
            view = page;
            Items = new ObservableCollection<CapturedCar>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            Initialize();
        }

        private void Initialize()
        {
            view.Search += new EventHandler<EventArgs>(ClickSearch);
            view.OnItem += new EventHandler<SelectedItemChangedEventArgs>(ClickOnItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            lock (loadLock)
            {
                try
                {
                    Items.Clear();
                    FindItems(view.SearchText);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        public ObservableCollection<CapturedCar> FindItems(String text)
        {
            Items.Clear();
            var items = service.FindByPlate(text);
            foreach (var item in items)
            {
                Items.Add(item);
            }
            return Items;
        }

        private async void ClickSearch(object sender, EventArgs e)
        {
            ITextValidator validator = new LicensePlateValidator();
            if (validator.IsValid(view.SearchText))
            {
                LoadItemsCommand.Execute(null);
            }
            else
            {
                await DialogAlertManager.GetInstance().ShowValidationDialogAlert(page);
            }
        }

        private async void ClickOnItem(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as CapturedCar;
            if (item == null)
                return;

            await NavigationManager.GetInstance().NavigateToSearchItem(page, new CarDetailModel(item));

            //Manually deselect item.
            view.ListView.SelectedItem = null;
        }
    }
}
