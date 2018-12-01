using MobileApp.Manager;
using MobileApp.Models;
using MobileApp.Views;
using Models.Cars;
using Services.Validation;
using Services.WebAPI.Cars;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Presenters
{
    public class SearchPresenter : BasePresenter
    {
        private ISearchView view;
        private readonly Page page;
        public ObservableCollection<CapturedCar> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private CapturedCarService service;

        public SearchPresenter(SearchPage page)
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
            view.Search += new EventHandler<EventArgs>(ClickSearch);
            view.OnItem += new EventHandler<SelectedItemChangedEventArgs>(ClickOnItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            try
            {
                Items.Clear();
                await GetItems(view.SearchText);
            }
            catch (Exception ex)
            {
                DialogAlertManager.GetInstance().ShowInternalDialogAlert(page);
            }
        }

        public async Task<ObservableCollection<CapturedCar>> GetItems(String text)
        {
            Items.Clear();
            var items = await service.GetByLicensePlateAsync(text);
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
            CapturedCar item = args.SelectedItem as CapturedCar;
            if (item == null)
                return;

            await NavigationManager.GetInstance().NavigateToSearchItem(page, new CarDetailModel(item));

            //Manually deselect item.
            view.ListView.SelectedItem = null;
        }
    }
}
