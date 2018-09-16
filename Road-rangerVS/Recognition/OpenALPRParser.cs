using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Road_rangerVS
{
    class OpenALPRParser : Parser
    {
        public List<ParsedCar> Parse(string data)
        {
            JObject o = JObject.Parse(data);

            JArray results = (JArray)o["results"];

            List<ParsedCar> cars = new List<ParsedCar>();

            foreach (JObject result in results)
            {
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

                cars.Add(new ParsedCar(plate, colorName, makeName, model, bodyType, year));
            }

            return cars;
        }

        public bool IsError(string data)
        {
            JObject o = JObject.Parse(data);
            JToken value;
            if (o.TryGetValue("error_code", out value))
                return true;
            else
                return false;
        }
    }
}
