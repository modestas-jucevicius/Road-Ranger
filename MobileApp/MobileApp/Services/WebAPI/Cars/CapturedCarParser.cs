using Models.Cars;
using Models.Images;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MobileApp.Services.WebAPI.Cars
{
    public class CapturedCarParser
    {
        public List<CapturedCar> Parse(string data)
        {
            JArray results = JArray.Parse(data);
            List<CapturedCar> cars = new List<CapturedCar>();

            foreach (JObject result in results)
                cars.Add(ParseUnit(result));

            return cars;
        }

        public CapturedCar ParseUnit(JObject result)
        {
            JObject image = (JObject)result["image"];

            Image img = new Image
            {
                Id = (string)image["id"],
                CarId = (string)image["carId"],
                Timestamp = (long)image["timestamp"],
                Path = (string)image["path"],
                Latitude = (double)image["latitude"],
                Longitude = (double)image["longitude"]
            };

            return new CapturedCar
            {
                Id = (string)result["id"],
                UserId = (string)result["userId"],
                LicensePlate = (string)result["licensePlate"],
                ColorName = (string)result["colorName"],
                MakeName = (string)result["makeName"],
                Model = (string)result["model"],
                BodyType = (string)result["bodyType"],
                Year = (string)result["year"],
                Status = (CarStatus)Enum.ToObject(typeof(CarStatus), (int)result["status"]),
                IsReported = (bool)result["isReported"],
                Image = img
            };
        }
    }
}
