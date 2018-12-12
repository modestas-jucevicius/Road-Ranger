using MobileApp.Manager;
using MobileApp.Models;
using MobileApp.Views;
using Models.Cars;
using MobileApp.Services.Validation;
using MobileApp.Services.WebAPI.Cars;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;

namespace MobileApp.Presenters
{
    public class SearchPresenter : BasePresenter
    {
        private ISearchView view;
        public ObservableCollection<CapturedCar> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private CapturedCarService service;

        public SearchPresenter(ISearchView view)
        {
            this.view = view;
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
        }

        private async Task ExecuteSearch()
        {
            Items.Clear();
            await GetItems(view.SearchText);

            if (Items.Count == 0)
                await DialogAlertManager.ShowNoCarRecord(view.Page);
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
            view.IsPressable = false;
            ITextValidator validator = new LicensePlateValidator();
            if (validator.IsValid(view.SearchText))
            {
                try
                {
                    await ExecuteSearch();
                    LoadItemsCommand.Execute(null);
                }
                catch (HttpRequestException)
                {
                    await DialogAlertManager.ShowNoCarRecord(view.Page);
                }
                catch (Exception)
                {
                    await DialogAlertManager.ShowInternalDialogAlert(view.Page);
                }
            }
            else
                await DialogAlertManager.ShowValidationDialogAlert(view.Page);
            view.IsPressable = true;
        }

        private async void ClickOnItem(object sender, SelectedItemChangedEventArgs args)
        {
            view.IsPressable = false;
            await TakeItem(args);
            view.IsPressable = true;
        }

        private async Task TakeItem(SelectedItemChangedEventArgs args)
        {
            CapturedCar item = args.SelectedItem as CapturedCar;
            if (item == null)
                return;

            await NavigationManager.NavigateToSearchItem(view.Page, new CarDetailModel(item));

            //Manually deselect item.
            view.ListView.SelectedItem = null;
        }
    }
}
