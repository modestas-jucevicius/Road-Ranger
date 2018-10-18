
using Road_rangerVS.Data;
using Road_rangerVS.Recognition;
using Road_rangerVS.Images;
using System.Collections.Generic;
using Road_rangerVS.Users;
using System.Linq;

namespace Road_rangerVS.Search
{
    class CapturedCarFinder : ICapturedCarFinder
    {
        private IUserData userData = new UserFileSystem();
        private ICarData carData = new CarFileSystem();
        private IImageData imageData = new ImageFileSystem();

        public List<CapturedCar> FindByPlate(string licensePlate)
        {
            List<Car> cars = carData.FindAll();
            List<Image> images = imageData.FindAll();
            IEnumerable<CapturedCar> capturedCars = new List<CapturedCar>();

            capturedCars = from car in cars
                           join image in images on car.id equals image.carId
                           where car.licensePlate.Equals(licensePlate)
                           orderby image.timestamp descending
                           select new CapturedCar(car, image);
            
            return capturedCars.ToList();
        }

        public List<CapturedCar> FindByUserId(int id)
        {
            List<Car> cars = carData.FindAll();
            List<Image> images = imageData.FindAll();

            IEnumerable<CapturedCar> capturedCars = from car in cars
                                                    join image in images on car.id equals image.carId
                                                    where car.userId == id
                                                    orderby image.timestamp descending
                                                    select new CapturedCar(car, image);

            return capturedCars.ToList();
        }
    }
}
