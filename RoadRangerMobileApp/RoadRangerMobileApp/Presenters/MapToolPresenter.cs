using RoadRangerBackEnd.CustomEventArgs;
using RoadRangerMobileApp.Models;
using RoadRangerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Android.Locations;

namespace RoadRangerMobileApp.Presenters
{
    public class MapToolPresenter
    {
        private IMapToolView view;
        private IMapModel model;

        public MapToolPresenter(IMapToolView page, IMapModel model)
        {
            this.view = page;
            this.model = model;
            Initialize();
            
        }
        private void Initialize()
        {
             view.SetLocation +=  new EventHandler(SetLocation);
             view.AddPins += new EventHandler<PinsEventArgs>(AddPins);
        }

        private async void SetLocation(object sender, EventArgs e)
        {
             Position pos = await model.GetLocation();
           // Position pos = new Position(54.687157, 25.279652); //Vilnius
            model.SetLocation(pos);
        }
        private void AddPins(object sender, PinsEventArgs args)
        {
            model.AddPins(args.Pins, args.Map);
        }

    }
}
