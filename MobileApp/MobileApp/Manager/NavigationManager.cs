using MobileApp.Models;
using MobileApp.Presenters;
using MobileApp.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Services.WebAPI.Authorization;

namespace MobileApp.Manager
{
    public class NavigationManager
    {
        private readonly AuthorizationService authorization = AuthorizationService.GetInstance();
        private static NavigationManager manager = null;

        private NavigationManager()
        {
        }

        public static NavigationManager GetInstance()
        {
            if (manager == null)
            {
                manager = new NavigationManager();
                return manager;
            }
            return manager;
        }

        public void NavigateToMain(IApp app)
        {
            MainPage mainPage = new MainPage();
            app.Main = mainPage;
            //RedirectToLogin(mainPage);
        }

        private async void RedirectToLogin(Page page)
        {
            string token = await SecureStorage.GetAsync("authToken");
            if (token != null)
            {
                try
                {
                    authorization.SetToken(token);
                    await authorization.GetCurrentUser();
                }
                catch (Exception ex)
                {
                    await NavigateToLogin(page);
                }
            }
            else
            {
                await NavigateToLogin(page);
            }
        }

        public async Task NavigateToMyGallery(Page page)
        {
            MyGalleryPage galleryPage = new MyGalleryPage();
            MyGalleryPresenter presenter = new MyGalleryPresenter(galleryPage);
            galleryPage.BindingContext = presenter;
            await page.Navigation.PushModalAsync(new NavigationPage(galleryPage));
        }

        public async Task NavigateToMap(Page page)
        {
            MapPage mapPage = new MapPage();
            new MapToolPresenter(mapPage, new MapModel(mapPage.GoogleMap));
            await page.Navigation.PushModalAsync(new NavigationPage(mapPage));
        }

        public async Task NavigateToSearch(Page page)
        {
            SearchPage searchPage = new SearchPage();
            SearchPresenter presenter = new SearchPresenter(searchPage);
            searchPage.BindingContext = presenter;
            await page.Navigation.PushModalAsync(new NavigationPage(searchPage));
        }

        public async Task NavigateToCamera(Page page)
        {
            CameraPage cameraPage = new CameraPage();
            CameraPresenter presenter = new CameraPresenter(cameraPage);
            await page.Navigation.PushModalAsync(new NavigationPage(cameraPage));
        }

        public async Task NavigateToLogin(Page page)
        {
            LoginPage loginPage = new LoginPage();
            LoginPresenter presenter = new LoginPresenter(loginPage);
            loginPage.BindingContext = presenter;
            await page.Navigation.PushModalAsync(new NavigationPage(loginPage));
        }

        public async Task NavigateToMyGalleryItem(Page page, CarDetailModel car)
        {
            MyGalleryItemPage itemPage = new MyGalleryItemPage();
            MyGalleryItemPresenter presenter = new MyGalleryItemPresenter(itemPage, car);
            itemPage.BindingContext = car;
            await page.Navigation.PushAsync(itemPage);
        }

        public async Task NavigateToReport(Page page)
        {
            await page.Navigation.PushModalAsync(new NavigationPage(new ReportPage()));
        }

        public async Task NavigateToSearchItem(Page page, CarDetailModel car)
        {
            SearchItemPage itemPage = new SearchItemPage();
            new SearchItemPresenter(itemPage, car);
            itemPage.BindingContext = car;
            await page.Navigation.PushAsync(itemPage);
        }

        public async Task NavigateToShop(Page page)
        {
            ShopPage shopPage = new ShopPage();
            new ShopPresenter(shopPage);
            await page.Navigation.PushModalAsync(new NavigationPage(shopPage));
        }

        public async Task NavigateToStatistic(Page page)
        {
            StatisticPage statisticPage = new StatisticPage();
            new StatisticPresenter(statisticPage);
            await page.Navigation.PushModalAsync(new NavigationPage(statisticPage));
        }

        public async Task NavigateToTop(Page page)
        {
            TopPage topPage = new TopPage();
            TopPresenter presenter = new TopPresenter(topPage);
            topPage.BindingContext = presenter;
            await page.Navigation.PushModalAsync(new NavigationPage(topPage));
        }

        public async Task NavigateBack(Page page)
        {
            await page.Navigation.PopModalAsync();
        }
    }
}
