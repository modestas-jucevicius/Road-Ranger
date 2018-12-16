using Models.Images;

namespace Models.Cars
{
    public class CarFactory
    {
        private static CarFactory instance = null;

        public static CarFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new CarFactory();
            }
            return instance;
        }

        private CarFactory()
        {
        }

        public CapturedCar CreateCapturedCar(Car car, Image image)
        {
            return new CapturedCar
            {
                Id = car.Id,
                UserId = car.UserId,
                LicensePlate = car.LicensePlate,
                ColorName = car.ColorName,
                MakeName = car.MakeName,
                Model = car.Model,
                BodyType = car.BodyType,
                Year = car.Year,
                Status = car.Status,
                IsReported = car.IsReported,
                Image = image
            };
        }

        public Car CreateCar(string id, string userId, string licensePlate, string colorName,
                            string makeName, string model, string bodyType, string year,
                            CarStatus status, bool isReported)
        {
            return new Car
            {
                Id = id,
                UserId = userId,
                LicensePlate = licensePlate,
                ColorName = colorName,
                MakeName = makeName,
                Model = model,
                BodyType = bodyType,
                Year = year,
                Status = status,
                IsReported = isReported
            };
        }

        public Car CreateCar(string licensePlate, string colorName,
                            string makeName, string model, string bodyType, string year)
        {
            return new Car
            {
                LicensePlate = licensePlate,
                ColorName = colorName,
                MakeName = makeName,
                Model = model,
                BodyType = bodyType,
                Year = year
            };
        }

    }
}
