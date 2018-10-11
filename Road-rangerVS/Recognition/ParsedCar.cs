using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Road_rangerVS.Data;
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
        public CarStatus status { get; set; }
        static int instanceNr = 1;
        private int ID;

		public ParsedCar(string licensePlate, string color, string makeModel, string model, string type, string year)
		{
			this.licensePlate = licensePlate;
			this.color = color;
			this.makeModel = makeModel;
			this.model = model;
			this.type = type;
			this.year = year;
            ID = instanceNr;
            instanceNr++;
		}

        // Išspausdina visus objekto duomenis konsolėje
        public async Task SetStatus(FileSystem<ParsedCar> file)
		{
            EPolicijaAPIRequester requester = EPolicijaAPIRequester.GetInstance();
            this.status = await requester.AskCarStatus(licensePlate);
            file.Put(this);
            /*
            if (status.Equals(CarStatus.STOLEN) || status.Equals(CarStatus.STOLEN_PLATE))
            {
                string row = "Car number is: " + licensePlate +
                        ".\n" + "The car IS STOLEN! Report?";
                file.Put(this);
                DialogResult dialogResult = MessageBox.Show(row, "Report", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ReportForm reportForm = new ReportForm();
                    reportForm.ShowDialog();
                }
            }
            else if (status.Equals(CarStatus.NOT_STOLEN))
            {
                string row = "Car number is: " + licensePlate + ".\n" + "The car is NOT STOLEN!";
                MessageBox.Show(row, "Report");
            }
            */
        }
        public int getID()
        {
            return ID;
        }

        public override string ToString()
        {
            return "toString(): " + licensePlate + "\n";
        }
    }
}
