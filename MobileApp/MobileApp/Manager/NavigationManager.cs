using MobileApp.Presenters;
using MobileApp.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using MobileApp.Pages;
using MobileApp.Services.WebAPI.Authorization;
using Models.Cars;

namespace MobileApp.Manager
{
    public class NavigationManager
    {
        private static readonly AuthorizationService authorization = AuthorizationService.GetInstance();

        public static async void NavigateToMain(Page page)
        {
            MainPage mainPage = new MainPage();
            MainPresenter presenter = new MainPresenter(mainPage);
            await page.Navigation.PushModalAsync(new NavigationPage(mainPage));
        }

        public static async void NavigateToMain(IApp app)
        {
            MainPage mainPage = new MainPage();
            app.Main = mainPage;
            //await RedirectToLogin(mainPage);
            MainPresenter presenter = new MainPresenter(mainPage);
        }

        public static async Task<bool> RedirectToLogin(Page page)
        {
            string token = await SecureStorage.GetAsync("authToken");
            if (token != null)
            {
                try
                {
                    authorization.SetToken(token);
                    await authorization.GetCurrentUser();
                    return false;
                }
                catch (Exception)
                {
                    NavigateToLogin(page);
                }
            }
            else
            {
                NavigateToLogin(page);
            }
            return true;
        }

        public static async Task NavigateToMyGallery(Page page)
        {
            MyGalleryPage galleryPage = new MyGalleryPage();
            MyGalleryPresenter presenter = new MyGalleryPresenter(galleryPage);
            galleryPage.BindingContext = presenter;
            await page.Navigation.PushModalAsync(new NavigationPage(galleryPage));
        }

        public static async Task NavigateToMap(Page page)
        {
            MapPage mapPage = new MapPage();
            new MapToolPresenter(mapPage);
            await page.Navigation.PushModalAsync(new NavigationPage(mapPage));
        }

        public static async Task NavigateToSearch(Page page)
        {
            SearchPage searchPage = new SearchPage();
            SearchPresenter presenter = new SearchPresenter(searchPage);
            searchPage.BindingContext = presenter;
            await page.Navigation.PushModalAsync(new NavigationPage(searchPage));
        }

        public static async Task NavigateToCamera(Page page)
        {
            CameraPage cameraPage = new CameraPage();
            CameraPresenter presenter = new CameraPresenter(cameraPage);
            await page.Navigation.PushModalAsync(new NavigationPage(cameraPage));
        }

        public async static void NavigateToLogin(Page page)
        {
            LoginPage loginPage = new LoginPage();
            LoginPresenter presenter = new LoginPresenter(loginPage);
            loginPage.BindingContext = presenter;
            await page.Navigation.PushModalAsync(new NavigationPage(loginPage));
        }

        public static async Task NavigateToMyGalleryItem(Page page, CapturedCar car)
        {
            MyGalleryItemPage itemPage = new MyGalleryItemPage();
            MyGalleryItemPresenter presenter = new MyGalleryItemPresenter(itemPage, car);
            itemPage.BindingContext = car;
            await page.Navigation.PushAsync(itemPage);
        }

        public static async Task NavigateToReport(Page page)
        {
            ReportPage reportPage = new ReportPage();
            ReportPresenter presenter = new ReportPresenter(reportPage);
            await page.Navigation.PushModalAsync(new NavigationPage(reportPage));
        }

        public static async Task NavigateToSearchItem(Page page, CapturedCar car)
        {
            SearchItemPage itemPage = new SearchItemPage();
            new SearchItemPresenter(itemPage, car);
            itemPage.BindingContext = car;
            await page.Navigation.PushAsync(itemPage);
        }

        public static async Task NavigateToShop(Page page)
        {
            ShopPage shopPage = new ShopPage();
            new ShopPresenter(shopPage);
            await page.Navigation.PushModalAsync(new NavigationPage(shopPage));
        }

        public static async Task NavigateToStatistic(Page page)
        {
            StatisticPage statisticPage = new StatisticPage();
            new StatisticPresenter(statisticPage);
            await page.Navigation.PushModalAsync(new NavigationPage(statisticPage));
        }

        public static async Task NavigateToTop(Page page)
        {
            TopPage topPage = new TopPage();
            TopPresenter presenter = new TopPresenter(topPage);
            topPage.BindingContext = presenter;
            await page.Navigation.PushModalAsync(new NavigationPage(topPage));
        }

        public static async Task NavigateToMore(Page page)
        {
            MorePage morePage = new MorePage();
            MorePresenter presenter = new MorePresenter(morePage);
            await page.Navigation.PushModalAsync(new NavigationPage(morePage));
        }

        public static async Task NavigateBack(Page page)
        {
            await page.Navigation.PopModalAsync();
        }
    }
}
