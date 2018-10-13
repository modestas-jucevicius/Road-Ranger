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

        // Tikrina, ar yra klaidos laukų (error_code) string'e data
        // Jei yra - grąžina true
        // Jei nėra - grąžina false
        public bool IsError(string data)
        {
            JObject o = JObject.Parse(data);
            JToken value;
            // mėgina gauti objekte o esančiame lauke error_code reikšmes:
            // jei yra laukas error_code - grąžina true ir error_code lauke esančios reikšmės priskiriamos kintamajam value 
            // jei nėra lauko error_code - grąžina false
            if (o.TryGetValue("error_code", out value))
                return true;
            else
                return false;
        }
    }
}
