
using Road_rangerVS.Data;
using Road_rangerVS.Recognition;
using Road_rangerVS.Images;
using System.Collections.Generic;
using Road_rangerVS.Users;

namespace Road_rangerVS.Search
{
    class CapturedCarFinder : ICapturedCarFinder
    {
        private FileSystem<User> userFileSystem = new FileSystem<User>(0);
        private FileSystem<Car> carFileSystem = new FileSystem<Car>(1);
        private FileSystem<Image> imageFileSystem = new FileSystem<Image>(2);

        public List<CapturedCar> FindByPlate(string licensePlate)
        {
            List<Car> cars = carFileSystem.FindAll();
            List<Image> images = imageFileSystem.FindAll();

            List<CapturedCar> capturedCars = new List<CapturedCar>();
            if (cars != null)
            {
                foreach (Car car in cars)
                {
                    if (car.licensePlate.Equals(licensePlate))
                    {
                        if (images != null)
                        {
                            foreach (Image image in images)
                            {
                                if (image.licensePlate.Equals(licensePlate))
                                {
                                    capturedCars.Add(new CapturedCar(car, image));
                                }
                            }
                        }
                    }
                }
            }
            
            return capturedCars;
        }

        public List<CapturedCar> FindByUserId(int id)
        {
            int userId = 0;

            User user = userFileSystem.FindById(userId);
            List<Car> cars = carFileSystem.FindAll();
            List<Image> images = imageFileSystem.FindAll();

            List<CapturedCar> capturedCars = new List<CapturedCar>();

            if (cars != null && user != null)
            {
                foreach (Car car in cars)
                {
                    if (car.userId.Equals(user.id))
                    {
                        string licensePlate = car.licensePlate;
                        if (images != null)
                        {
                            foreach (Image image in images)
                            {
                                if (image.licensePlate.Equals(licensePlate))
                                {
                                    capturedCars.Add(new CapturedCar(car, image));
                                }
                            }
                        }
                    }
                }
            }

            return capturedCars;
        }
    }
}
