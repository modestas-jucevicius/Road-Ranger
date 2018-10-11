using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.OutsideAPI;

namespace Road_rangerVS
{
	class ParsedCar
	{
		public string licensePlate { get; set; }  // automobilio registracijos numeris
		public string color { get; set; }               // automobilio spalva
		public string makeModel { get; set; }           // automobilio gamintojas (volkswagen, volvo...)
		public string model { get; set; }               // automobilio modelis
		public string type { get; set; }                // automobilio tipas (sedanas, universalas...)
		public string year { get; set; }                // automobilio pagaminimo metai

		public ParsedCar(string licensePlate, string color, string makeModel, string model, string type, string year)
		{
			this.licensePlate = licensePlate;
			this.color = color;
			this.makeModel = makeModel;
			this.model = model;
			this.type = type;
			this.year = year;
		}

        public async Task<CarStatus> getCarStatus()
        {
            EPolicijaAPIRequester requester = new EPolicijaAPIRequester();
            return await requester.getCarStatus(this);
        }

	}
}
