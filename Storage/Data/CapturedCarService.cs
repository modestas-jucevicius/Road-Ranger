using System.Collections.Generic;
using System.Linq;
using Models.Cars;
using Models.Images;
using Storage.Data.Cars;
using Storage.Data.Images;

namespace Storage.Data
{
    public class CapturedCarService
    {
        private ICarData carData = new CarMemoryData();
        private IImageData imageData = new ImageMemoryData();

        public List<CapturedCar> FindByPlate(string licensePlate)
        {
            List<Car> cars = carData.FindAll();
            List<Image> images = imageData.FindAll();
            IEnumerable<CapturedCar> capturedCars = new List<CapturedCar>();

            capturedCars = from car in cars
                           join image in images on car.Id equals image.CarId
                           where car.LicensePlate.Equals(licensePlate)
                           orderby image.Timestamp descending
                           select CarFactory.GetInstance().CreateCapturedCar(car, image);
            
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
                                                    select CarFactory.GetInstance().CreateCapturedCar(car, image);

            return capturedCars.ToList();
        }

        public List<CapturedCar> FindAll()
        {
            List<Car> cars = carData.FindAll();
            List<Image> images = imageData.FindAll();

            IEnumerable<CapturedCar> capturedCars = from car in cars
                                                    join image in images on car.Id equals image.CarId
                                                    select CarFactory.GetInstance().CreateCapturedCar(car, image);
            return capturedCars.ToList();
        }

        public void Add(CapturedCar car)
        {
            carData.Put(car);
            imageData.Put(car.Image);
        }

        public void RemoveByCarId(int id)
        {
            Car car = carData.FindById(id);
            if (car != null)
            {
                List<Image> images = imageData.FindAll();

                IEnumerable<Image> imgs = from image in images
                                          where car.Id == image.CarId
                                          select image;

                carData.Remove(car.Id);
                foreach (var img in imgs.ToList())
                {
                    imageData.Remove(img.Id);
                }
            }
        }
    }
}
