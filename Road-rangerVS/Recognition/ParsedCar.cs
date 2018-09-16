using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS
{
    class ParsedCar
    {
        public string registrationNumber { get; set; }
        public string color { get; set; }
        public string makeModel { get; set; }
        public string model { get; set; }
        public string type { get; set; }
        public string year { get; set; }

        public ParsedCar(string registrationNumber, string color, string makeModel, string model, string type, string year)
        {
            this.registrationNumber = registrationNumber;
            this.color = color;
            this.makeModel = makeModel;
            this.model = model;
            this.type = type;
            this.year = year;
        }

        public void Display()
        {
            Console.WriteLine("registrationNumber: {0}, color: {1}, makeModel: {2}, model: {3}, type: {4}, year: {5}", registrationNumber, color, makeModel, model, type, year);
        }
    }
}
