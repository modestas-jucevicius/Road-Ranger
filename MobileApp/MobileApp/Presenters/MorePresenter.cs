using MobileApp.Manager;
using MobileApp.Views;
using System;

namespace MobileApp.Presenters
{
    public class MorePresenter
    {
        private IMoreView view;

        public MorePresenter(IMoreView view)
        {
            this.view = view;
            Initialize();
        }

        private void Initialize()
        {
            view.MyGalleryClick += new EventHandler<EventArgs>(MyGallery);
            view.ReportClick += new EventHandler<EventArgs>(Report);
            view.StatsClick += new EventHandler<EventArgs>(Stats);
            view.MapClick += new EventHandler<EventArgs>(Map); ;
        }

        private async void MyGallery(object sender, EventArgs args)
        {
            view.IsPressable = false;
            await NavigationManager.NavigateToMyGallery(view.Page);
            view.IsPressable = true;
        }

        private async void Report(object sender, EventArgs args)
        {
            view.IsPressable = false;
            await NavigationManager.NavigateToReport(view.Page);
            view.IsPressable = true;
        }

        private async void Stats(object sender, EventArgs args)
        {
            view.IsPressable = false;
            await NavigationManager.NavigateToStatistic(view.Page);
            view.IsPressable = true;
        }

        private async void Map(object sender, EventArgs args)
        {
            view.IsPressable = false;
            await NavigationManager.NavigateToMap(view.Page);
            view.IsPressable = true;
        }
    }
}
