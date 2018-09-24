using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.OutsideAPI;
using System.Windows.Forms;

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

		public ParsedCar(string registrationNumber, string color, string makeModel, string model, string type, string year)
		{
			this.registrationNumber = registrationNumber;
			this.color = color;
			this.makeModel = makeModel;
			this.model = model;
			this.type = type;
			this.year = year;
		}

		// Išspausdina visus objekto duomenis konsolėje
		public async Task Display()
		{
			Console.WriteLine("registrationNumber: {0}, color: {1}, makeModel: {2}, model: {3}, type: {4}, year: {5}", registrationNumber, color, makeModel, model, type, year);
			EPolicijaAPI ePolicijaAPI = EPolicijaAPI.getInstance(); // pasiema EPolicijosAPI objekta
			try
			{
				if (await ePolicijaAPI.IsCarStolen(registrationNumber)) // tikrina masina vogta ar ne
				{
                    if (MessageBox.Show("Car is stolen, report?", "Report",
                       MessageBoxButtons.YesNo) == DialogResult.Yes)  //Atidaro langą su pranešimo galimybe
                    {
                        System.Diagnostics.Process.Start("https://www.epolicija.lt/report-anonymous");
                        //Nukreipia į pranešimo policijai puslapį
                    }
                }
				else
				{
                    MessageBox.Show("Car is not stolen!"); //atidaro langą ir parodo, kad mašina nėra vogta
                }
			}
			catch (LicenceNumberParseException e) //jei negali patikrinti pagal duotus duomenis meta exceptiona
			{
				Console.WriteLine(e);
			}

		}
	}
}
