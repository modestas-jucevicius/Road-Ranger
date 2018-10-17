
using Road_rangerVS.Data;
using Road_rangerVS.Recognition;
using Road_rangerVS.Images;
using System.Collections.Generic;
using Road_rangerVS.Users;

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

            List<CapturedCar> capturedCars = new List<CapturedCar>();
            if (cars != null)
            {
                foreach (Car car in cars)
                {
                    if (car.licensePlate.Equals(licensePlate))
                    {
                        System.Console.WriteLine(licensePlate);
                        if (images != null)
                        {
                            foreach (Image image in images)
                            {
                                if (image.carId.Equals(car.id))
                                {
                                    capturedCars.Add(new CapturedCar(car, image));
                                }
                            }
                        }
                        else
                        {
                            capturedCars.Add(new CapturedCar(car, null));
                        }
                    }
                }
            }
            
            return capturedCars;
        }

        public List<CapturedCar> FindByUserId(int id)
        {
            int userId = 0;

            User user = userData.FindById(userId);
            List<Car> cars = carData.FindAll();
            List<Image> images = imageData.FindAll();

            List<CapturedCar> capturedCars = new List<CapturedCar>();

            if (cars != null && user != null)
            {
                foreach (Car car in cars)
                {
                    if (car.userId.Equals(user.id))
                    {
                        int carId = car.id;
                        if (images != null)
                        {
                            foreach (Image image in images)
                            {
                                if (image.carId.Equals(carId))
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
