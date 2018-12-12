using MobileApp.Models;
using MobileApp.Presenters;
using MobileApp.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using MobileApp.Pages;
using MobileApp.Services.WebAPI.Authorization;

namespace MobileApp.Manager
{
    public class NavigationManager
    {
        private static readonly AuthorizationService authorization = AuthorizationService.GetInstance();

        public static async void NavigateToMain(Page page)
        {
            MainPage mainPage = new MainPage();
            await page.Navigation.PushModalAsync(new NavigationPage(mainPage));
        }

        private static async void RedirectToLogin(IApp app)
        {
            string token = await SecureStorage.GetAsync("authToken");
            if (token != null)
            {
                try
                {
                    authorization.SetToken(token);
                    await authorization.GetCurrentUser();
                }
                catch (Exception)
                {
                    await NavigateToLogin(app);
                }
            }
            else
            {
                await NavigateToLogin(app);
            }
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
            new MapToolPresenter(mapPage, new MapModel(mapPage.GoogleMap));
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

        public static async Task NavigateToLogin(IApp app)
        {
            LoginPage loginPage = new LoginPage();
            LoginPresenter presenter = new LoginPresenter(loginPage);
            loginPage.BindingContext = presenter;
            app.Main = loginPage;
            //await page.Navigation.PushModalAsync(new NavigationPage(loginPage));
        }

        public static async Task NavigateToMyGalleryItem(Page page, CarDetailModel car)
        {
            MyGalleryItemPage itemPage = new MyGalleryItemPage();
            MyGalleryItemPresenter presenter = new MyGalleryItemPresenter(itemPage, car);
            itemPage.BindingContext = car;
            await page.Navigation.PushAsync(itemPage);
        }

        public static async Task NavigateToReport(Page page)
        {
            await page.Navigation.PushModalAsync(new NavigationPage(new ReportPage()));
        }

        public static async Task NavigateToSearchItem(Page page, CarDetailModel car)
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
            await page.Navigation.PushModalAsync(new NavigationPage(morePage));
        }

        public static async Task NavigateBack(Page page)
        {
            await page.Navigation.PopModalAsync();
        }
    }
}
