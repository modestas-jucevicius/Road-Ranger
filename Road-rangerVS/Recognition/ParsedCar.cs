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
        public string registrationNumber { get; set; }  // automobilio registracijos numeris
        public string color { get; set; }               // automobilio spalva
        public string makeModel { get; set; }           // automobilio gamintojas (volkswagen, volvo...)
        public string model { get; set; }               // automobilio modelis
        public string type { get; set; }                // automobilio tipas (sedanas, universalas...)
        public string year { get; set; }                // automobilio pagaminimo metai
        static int instanceNr = 1;
        private int ID;

		public ParsedCar(string registrationNumber, string color, string makeModel, string model, string type, string year)
		{
			this.registrationNumber = registrationNumber;
			this.color = color;
			this.makeModel = makeModel;
			this.model = model;
			this.type = type;
			this.year = year;
            ID = instanceNr;
            instanceNr++;
		}

		// Išspausdina visus objekto duomenis konsolėje
		public async Task Display(FileSystem file)
		{
			Console.WriteLine("registrationNumber: {0}, color: {1}, makeModel: {2}, model: {3}, type: {4}, year: {5}", registrationNumber, color, makeModel, model, type, year);
			EPolicijaAPI ePolicijaAPI = EPolicijaAPI.getInstance(); // pasiema EPolicijosAPI objekta
			try
			{
				if (await ePolicijaAPI.IsCarStolen(registrationNumber)) // tikrina masina vogta ar ne
				{
                    string row = "Car number is: " + registrationNumber +
                        ".\n" + "The car IS STOLEN! Report?";
                    file.putData(this, true);
                    DialogResult dialogResult  = MessageBox.Show(row,"Report", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ReportForm reportForm = new ReportForm();
                        reportForm.ShowDialog();
                    }
                }
				else
				{
                    file.putData(this, false);
                    string row = "Car number is: " + registrationNumber + ".\n" + "The car is NOT STOLEN!";
                    MessageBox.Show(row,"Report");
                }
			}
			catch (LicenceNumberParseException e) //jei negali patikrinti pagal duotus duomenis meta exceptiona
			{
				Console.WriteLine(e);
			}

		}
        public int getID()
        {
            return ID;
        }
	}
}
