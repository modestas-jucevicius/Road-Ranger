using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Manager
{
    public class DialogAlertManager
    {
        public static async Task<bool> ShowReportDialog(Page page)
        {
            return await page.DisplayAlert("Report", "Would you like to report a car?", "Yes", "No");
        }

        public static async Task<bool> ShowRemoveDialog(Page page)
        {
            return await page.DisplayAlert("Remove", "Are you sure you want to remove this car?", "Yes", "No");
        }

        public static async Task ShowInvalidRemoveDialogAlert(Page page)
        {
            await page.DisplayAlert("Remove", "You can not remove this car!", "OK");
        }

        public static async Task ShowInvalidReportDialogAlert(Page page)
        {
            await page.DisplayAlert("Report", "You can not report this car!", "OK");
        }

        public static async Task ShowReportSendAlert(Page page)
        {
            await page.DisplayAlert("Report", "Because of internal issues you can not report. Please try again!", "OK");
        }

        public static async Task ShowReportWasSentAlert(Page page)
        {
            await page.DisplayAlert("Report", "Your report was successfully sent!", "OK");
        }

        public static async Task ShowReportValidation(Page page)
        {
            await page.DisplayAlert("Report", "Subject and message should not be empty!", "OK");
        }

        public static async Task ShowValidationDialogAlert(Page page)
        {
            await page.DisplayAlert("License plate", "Car license plate is not valid! License plate should be AAA000 or AA000 format.", "OK");
        }

        public static async Task ShowNoCarRecord(Page page)
        {
            await page.DisplayAlert("License plate", "There is no matching car record!", "OK");
        }

        public static async Task ShowNoInternetConnection(Page page)
        {
            await page.DisplayAlert("Internet unavailable", "Internet connection is required. Please enable it!", "OK");
        }

        public static async Task ShowNotEnoughScoreDialogAlert(Page page)
        {
            await page.DisplayAlert("Shop", "You have not enough score points.", "OK");
        }

        public static async Task ShowInternalDialogAlert(Page page)
        {
            await page.DisplayAlert("Server", "We say sorry, our web service is shut down. Please try later.", "OK");
        }

        public static async Task ShowAuthentificationInputValidation(Page page)
        {
            await page.DisplayAlert("Authentification", "Password and username should contain at least 7 charracters and no more than 24 characters.", "OK");
        }

        public static async Task ShowBadLoginOrPassword(Page page)
        {
            await page.DisplayAlert("Authentification", "The user name or password is incorrect!", "OK");
        }

        public static async Task ShowLoggedIn(Page page)
        {
            await page.DisplayAlert("Authentification", "You have successfully logged in.", "OK");
        }

        public static async Task ShowRegistered(Page page)
        {
            await page.DisplayAlert("Authentification", "You have successfully registered.", "OK");
        }

        public static async Task ShowNotAvailableUsername(Page page)
        {
            await page.DisplayAlert("Authentification", "This username is not available!", "OK");
        }

        public static async Task ShowMapInternalDialogAlert(Page page)
        {
            await page.DisplayAlert("Server", "We say sorry, our web service is shut down. Cars weren't add.", "OK");
        }
    }
}
