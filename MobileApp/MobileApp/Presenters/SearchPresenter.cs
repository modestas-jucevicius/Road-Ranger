using MobileApp.Manager;
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
            var items = await service.GetByLicensePlateAsync(view.SearchText);
            foreach (var item in items)
            {
                Items.Add(item);
            }

            if (Items.Count == 0)
                await DialogAlertManager.ShowNoCarRecord(view.Page);
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
            CapturedCar item = args.SelectedItem as CapturedCar;
            if (item == null)
                return;

            await NavigationManager.NavigateToSearchItem(view.Page, item);

            //Manually deselect item.
            view.ListView.SelectedItem = null;
            view.IsPressable = true;
        }
    }
}
