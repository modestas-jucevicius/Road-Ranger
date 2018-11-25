using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Manager
{
    public class DialogAlertManager
    {
        private static DialogAlertManager manager = null;

        public static DialogAlertManager GetInstance()
        {
            if (manager == null)
            {
                manager = new DialogAlertManager();
            }
            return manager;
        }

        private DialogAlertManager()
        {
        }

        // MyGalleryItem + SearchItem
        public async Task<bool> ShowReportDialog(Page page)
        {
            return await page.DisplayAlert("Report", "Would you like to report a car?", "Yes", "No");
        }

        public async Task<bool> ShowRemoveDialog(Page page)
        {
            return await page.DisplayAlert("Remove", "Are you sure you want to reamove this car?", "Yes", "No");
        }

        public async Task ShowInvalidRemoveDialogAlert(Page page)
        {
            await page.DisplayAlert("Remove", "You can not remove this car!", "OK");
        }

        public async Task ShowInvalidReportDialogAlert(Page page)
        {
            await page.DisplayAlert("Report", "You can not report this car!", "OK");
        }


        // Report
        public async Task ShowReportSendAlert(Page page)
        {
            await page.DisplayAlert("Report", "Because of internal issues you can not report. Please try again!", "OK");
        }

        // Search
        public async Task ShowValidationDialogAlert(Page page)
        {
            await page.DisplayAlert("License plate", "Car license plate is not valid! License plate should be AAA000 or AA000 format.", "OK");
        }

        // Shop
        public async Task ShowNotEnoughScoreDialogAlert(Page page)
        {
            await page.DisplayAlert("Shop", "You have not enough score points.", "OK");
        }

        // Server
        public async Task ShowInternalDialogAlert(Page page)
        {
            await page.DisplayAlert("Server", "Internal server issue. Please try again.", "OK");
        }
    }
}
