
using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Search;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMobileAppExample1.Models;

namespace RoadRangerMobileApp.ViewModels
{
    public class MyGalleryViewModel : BaseViewModel
    {

        public ObservableCollection<CapturedCar> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private ICapturedCarFinder finder = new CapturedCarFinder();

        public MyGalleryViewModel()
        {
            Items = new ObservableCollection<CapturedCar>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                //var items = await DataStore.GetItemsAsync(true);
                var items = finder.FindAll();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
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

    }
}
