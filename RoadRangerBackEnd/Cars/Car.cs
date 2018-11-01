using RoadRangerBackEnd.OutsideAPI;

namespace RoadRangerBackEnd.Cars
{
    public class Car
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LicensePlate { get; set; }    // automobilio registracijos numeris
        public string ColorName { get; set; }       // spalva
        public string MakeName { get; set; }        // gamintojo pavadinimas
        public string Model { get; set; }           // modelis
        public string BodyType { get; set; }        // tipas
        public string Year { get; set; }            // pagaminimo metai
        public CarStatus Status { get; set; }
        public bool IsReported {get; set;}

        public Car(Car car)
        {
            this.Id = car.Id;
            this.UserId = car.UserId;
            this.LicensePlate = car.LicensePlate;
            this.ColorName = car.ColorName;
            this.MakeName = car.MakeName;
            this.Model = car.Model;
            this.BodyType = car.BodyType;
            this.Year = car.Year;
            this.Status = car.Status;
            this.IsReported = car.IsReported;
        }

        public Car(string licensePlate, string colorName, string makeName, 
            string model, string bodyType, string year)
        {
            this.LicensePlate = licensePlate;
            this.ColorName = colorName;
            this.MakeName = makeName;
            this.Model = model;
            this.BodyType = bodyType;
            this.Year = year;
        }

        public Car(int id, int userId, string licensePlate, string colorName, 
            string makeName, string model, string bodyType, string year, bool isReported, CarStatus status) 
            : this(licensePlate, colorName, makeName, model, bodyType, year)
        {
            this.Id = id;
            this.UserId = userId;
            this.Status = status;
            this.IsReported = isReported;
        }
    }
}
