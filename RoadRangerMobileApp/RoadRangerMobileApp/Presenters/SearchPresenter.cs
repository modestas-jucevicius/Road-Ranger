using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Search;
using RoadRangerBackEnd.Validation;
using RoadRangerMobileApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RoadRangerMobileApp.Presenters
{
    public class SearchPresenter : BasePresenter
    {
        private ISearchView view;
        public ObservableCollection<CapturedCar> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private ICapturedCarFinder finder = new CapturedCarFinder();

        public SearchPresenter(ISearchView page)
        {
            this.view = page;
            Items = new ObservableCollection<CapturedCar>();
            LoadItemsCommand = new Command(async () => ExecuteLoadItemsCommand());
            this.Initialize();
        }

        private void Initialize()
        {
            this.view.Search += new EventHandler<EventArgs>(ClickSearch);
            this.view.OnItem += new EventHandler<SelectedItemChangedEventArgs>(ClickOnItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                FindItems(view.SearchText);
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

        public ObservableCollection<CapturedCar> FindItems(String text)
        {
            Items.Clear();
            var items = finder.FindByPlate(text);
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
                await view.ShowValidationDialogAlert();
            }
        }

        private async void ClickOnItem(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as CapturedCar;
            if (item == null)
                return;

            await view.NavigateToCapturedCarDetailPage(item);

            //Manually deselect item.
            view.ListView.SelectedItem = null;
        }
    }
}
