
using Road_rangerVS.Data;
using Road_rangerVS.Recognition;
using Road_rangerVS.Images;
using System.Collections.Generic;
using Road_rangerVS.Users;
using System.Linq;

namespace Road_rangerVS.Search
{
    public class CapturedCarFinder : ICapturedCarFinder
    {
        private readonly IUserData userData = UserFileSystem.GetInstance();
        private ICarData carData = new CarFileSystem();
        private IImageData imageData = new ImageFileSystem();

        public List<CapturedCar> FindByPlate(string licensePlate)
        {
            List<Car> cars = carData.FindAll();
            List<Image> images = imageData.FindAll();
            IEnumerable<CapturedCar> capturedCars = new List<CapturedCar>();

            capturedCars = from car in cars
                           join image in images on car.Id equals image.CarId
                           where car.LicensePlate.Equals(licensePlate)
                           orderby image.Timestamp descending
                           select new CapturedCar(car, image);
            
            return capturedCars.ToList();
        }

        public List<CapturedCar> FindByUserId(int id)
        {
            List<Car> cars = carData.FindAll();
            List<Image> images = imageData.FindAll();

            IEnumerable<CapturedCar> capturedCars = from car in cars
                                                    join image in images on car.Id equals image.CarId
                                                    where car.UserId == id
                                                    orderby image.Timestamp descending
                                                    select new CapturedCar(car, image);

            return capturedCars.ToList();
        }
    }
}
