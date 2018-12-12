using MobileApp.Manager;
using MobileApp.Views;
using System;

namespace MobileApp.Presenters
{
    public class MainPresenter : BasePresenter
    {
        private IMainView view;

        public MainPresenter(IMainView view)
        {
            this.view = view;
            Initialize();
        }

        private void Initialize()
        {
            view.SearchClick += new EventHandler<EventArgs>(Search);
            view.StartClick += new EventHandler<EventArgs>(Start);
            view.MoreClick += new EventHandler<EventArgs>(More);
            view.TopClick += new EventHandler<EventArgs>(Top);
            view.ShopClick += new EventHandler<EventArgs>(Shop);
        }

        private async void Search(object sender, EventArgs args)
        {
            view.IsPressable = false;
            await NavigationManager.NavigateToSearch(view.Page);
            view.IsPressable = true;
        }

        private async void Start(object sender, EventArgs args)
        {
            view.IsPressable = false;
            await NavigationManager.NavigateToCamera(view.Page);
            view.IsPressable = true;
        }

        private async void More(object sender, EventArgs args)
        {
            view.IsPressable = false;
            await NavigationManager.NavigateToMore(view.Page);
            view.IsPressable = true;
        }

        private async void Top(object sender, EventArgs args)
        {
            view.IsPressable = false;
            await NavigationManager.NavigateToTop(view.Page);
            view.IsPressable = true;
        }

        private async void Shop(object sender, EventArgs args)
        {
            view.IsPressable = false;
            await NavigationManager.NavigateToShop(view.Page);
            view.IsPressable = true;
        }
    }
}
