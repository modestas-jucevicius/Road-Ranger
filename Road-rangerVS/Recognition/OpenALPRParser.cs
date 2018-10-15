using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Road_rangerVS.Recognition;

namespace Road_rangerVS
{
    class OpenALPRParser : ICarParser
    {
        // Analizuoja duomenis data ir grąžina sąrašą sudarytą iš ParsedCar objektų
        public List<Car> Parse(string data)
        {
            JObject o = JObject.Parse(data);    // konvertuoja string data į JObject'ą o
			JToken errorValue;
			if (o.TryGetValue("error_code", out errorValue))
			{
				throw new ParseException("Error Parsing Image");
			}

			JArray results = (JArray)o["results"];  // paima o objekte results lauke esančias reikšmes ir konvertuoja į JArray objektą
            List<Car> cars = new List<Car>();

            foreach (JObject result in results)
            {
                // iš JSON formato (objekto result) paima informaciją apie automobilį:
                string plate = (string)result["plate"];

                JObject vehicle = (JObject)result["vehicle"];

                JArray colors = (JArray)vehicle["color"];
                JObject colorObj = (JObject)colors[0];
                string colorName = (string)colorObj["name"];

                JArray makes = (JArray)vehicle["make"];
                JObject makeObj = (JObject)makes[0];
                string makeName = (string)makeObj["name"];

                JArray bodies = (JArray)vehicle["body_type"];
                JObject bodyObj = (JObject)bodies[0];
                string bodyType = (string)bodyObj["name"];

                JArray years = (JArray)vehicle["year"];
                JObject yearObj = (JObject)years[0];
                string year = (string)yearObj["name"];

                JArray models = (JArray)vehicle["make_model"];
                JObject modelObj = (JObject)models[0];
                string model = (string)modelObj["name"];

                cars.Add(new Car(plate, colorName, makeName, model, bodyType, year));
            }

            return cars;
        }
    }
}
