using MobileApp.Views;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using Models.Cars;
using MobileApp.Services.Maps;
using MobileApp.Services.WebAPI.Cars;
using MobileApp.Manager;
using System.Net;

namespace MobileApp.Presenters
{
    public class MapToolPresenter
    {
        private readonly IMapToolView view;
        private CapturedCarService service;
        private readonly IMapTool mapTool;

        public MapToolPresenter(IMapToolView view)
        {
            this.view = view;
            service = new CapturedCarService();
            mapTool = new MapTool(view.GoogleMap);
            AddPins(view.GoogleMap);
        }

        public async void AddPins(Map map)
        {
            try
            {
                List<Pin> pins = new List<Pin>();
                List<CapturedCar> cars = await service.GetAll();
                CarsToPinsConverter.ConvertToPins(pins, cars);
                mapTool.AddPins(pins, map);
            }
            catch (WebException)
            {
                await DialogAlertManager.ShowMapInternalDialogAlert(view.Page);
            }
            catch
            {
                await DialogAlertManager.ShowInternalDialogAlert(view.Page);
                await NavigationManager.NavigateBack(view.Page);
            }
        }
    }
}
