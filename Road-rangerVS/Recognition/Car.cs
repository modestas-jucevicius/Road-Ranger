﻿using Road_rangerVS.OutsideAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.Recognition
{
    class Car
    {
        static int instanceNr = 1;
        private int id;
        public int userId { get; set; }
        public string licensePlate { get; set; }    // automobilio registracijos numeris
        public string colorName { get; set; }       // spalva
        public string makeName { get; set; }        // gamintojo pavadinimas
        public string model { get; set; }           // modelis
        public string bodyType { get; set; }        // tipas
        public string year { get; set; }            // pagaminimo metai
        public CarStatus status { get; set; }

        private Car()
        {
            this.id = instanceNr;
            instanceNr++;
        }
        public Car(String[] fields)
        {
            userId = Int32.Parse(fields[0]);
            licensePlate = fields[1];
            colorName = fields[2];
            makeName = fields[3];
            model = fields[4];
            bodyType = fields[5];
            year = fields[6];
            status = (CarStatus)Enum.Parse(typeof(CarStatus), fields[7]);
        }
        public Car(Car car) : this()
        {
            this.licensePlate = car.licensePlate;
            this.colorName = car.colorName;
            this.makeName = car.makeName;
            this.model = car.model;
            this.bodyType = car.bodyType;
            this.year = car.year;
        }

        public Car(string licensePlate, string colorName, string makeName, string model, string bodyType, string year) : this()
        {
            this.licensePlate = licensePlate;
            this.colorName = colorName;
            this.makeName = makeName;
            this.model = model;
            this.bodyType = bodyType;
            this.year = year;
        }

        public int getId()
        {
            return id;
        }
        override public string ToString()
        {
            string line = userId + "," + licensePlate + "," + colorName +
                 "," + makeName + "," + model + "," + bodyType + "," + year + 
                 "," + status + Environment.NewLine;
            return line;
        }
    }
}
