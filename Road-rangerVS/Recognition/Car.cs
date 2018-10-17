using Road_rangerVS.Data;
using Road_rangerVS.OutsideAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.Recognition
{
    class Car
    {
        //static int instanceId = -1;
        public int id { get; set; }
        public int userId { get; set; }
        public string licensePlate { get; set; }    // automobilio registracijos numeris
        public string colorName { get; set; }       // spalva
        public string makeName { get; set; }        // gamintojo pavadinimas
        public string model { get; set; }           // modelis
        public string bodyType { get; set; }        // tipas
        public string year { get; set; }            // pagaminimo metai
        public CarStatus status { get; set; }

        public Car(String[] fields)
        {
            userId = Int32.Parse(fields[1]);
            licensePlate = fields[2];
            colorName = fields[3];
            makeName = fields[4];
            model = fields[5];
            bodyType = fields[6];
            year = fields[7];
            status = (CarStatus)Enum.Parse(typeof(CarStatus), fields[8]);
        }
        public Car(Car car)
        {
            this.licensePlate = car.licensePlate;
            this.colorName = car.colorName;
            this.makeName = car.makeName;
            this.model = car.model;
            this.bodyType = car.bodyType;
            this.year = car.year;
        }

        public Car(string licensePlate, string colorName, string makeName, string model, string bodyType, string year)
        {
            this.licensePlate = licensePlate;
            this.colorName = colorName;
            this.makeName = makeName;
            this.model = model;
            this.bodyType = bodyType;
            this.year = year;
        }

        override public string ToString()
        {
            string line = id + "," + userId + "," + licensePlate + "," + colorName +
                 "," + makeName + "," + model + "," + bodyType + "," + year + 
                 "," + status + Environment.NewLine;
            return line;
        }
    }
}
