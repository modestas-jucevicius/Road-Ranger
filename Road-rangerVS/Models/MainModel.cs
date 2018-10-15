using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Data;
using Road_rangerVS.Recognition;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Road_rangerVS.Models
{
	class MainModel
	{
		public FileSystem<Car> file { get; set; }
		public FilterInfoCollection videoCaptureDevices { get; set; }
		public VideoCaptureDevice finalVideo { get; set; }

		public MainModel()
		{
			file = new FileSystem<Car>(1);
		}
	}
}
