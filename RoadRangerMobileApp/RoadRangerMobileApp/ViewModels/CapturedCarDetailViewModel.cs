﻿using Road_rangerVS.Models;
using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Report;

namespace RoadRangerMobileApp.ViewModels
{
    public class CapturedCarDetailViewModel : BasePresenter
    {
        public CapturedCar Item { get; set; }
        public CapturedCarDetailViewModel(CapturedCar item = null)
        {
            Item = item;
        }
    }
}
