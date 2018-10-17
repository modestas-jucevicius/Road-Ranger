using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Data;
using Road_rangerVS.Recognition;
using AForge.Video;
using AForge.Video.DirectShow;
using Road_rangerVS.Images;

namespace Road_rangerVS.Models
{
	class MainModel
	{
		public ICarData carData { get; set; }
        public IImageData imageData { get; set; }
		public FilterInfoCollection videoCaptureDevices { get; set; }
		public VideoCaptureDevice finalVideo { get; set; }

		public MainModel()
		{
            carData = new CarFileSystem();
            imageData = new ImageFileSystem();
        }
	}
}
