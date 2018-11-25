using MobileApp.Views;
using MobileApp.Models;
using Services.CustomEventArgs;
using System;
using Xamarin.Forms.Maps;
using Xamarin.Forms;

namespace MobileApp.Presenters
{
    public class MapToolPresenter
    {
        private readonly IMapToolView view;
        private readonly Page page;
        private readonly IMapModel model;

        public MapToolPresenter(MapPage page, IMapModel model)
        {
            this.page = page;
            view = page;
            this.model = model;
            Initialize();
        }

        private void Initialize()
        {
             //view.SetLocation +=  new EventHandler(SetLocation);
             //view.AddPins += new EventHandler<PinsEventArgs>(AddPins);
        }

        private async void SetLocation(object sender, EventArgs e)
        {
            /*
            Position pos = await model.GetLocation();
            // Position pos = new Position(54.687157, 25.279652); //Vilnius
            model.SetLocation(pos);
            */
        }

        private void AddPins(object sender, PinsEventArgs args)
        {
            //model.AddPins(args.Pins, args.Map);
        }

    }
}
