﻿using MobileApp.Views;
using MobileApp.Models;
using Services.CustomEventArgs;
using System;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using System.Collections.Generic;

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
            AddPins();
        }
        private void AddPins()
        {
            model.AddPins(view.GoogleMap);
        }
    }
}
