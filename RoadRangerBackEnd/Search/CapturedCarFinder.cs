﻿using RoadRangerBackEnd.Data;
using RoadRangerBackEnd.Images;
using System.Collections.Generic;
using System.Linq;
using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Data.Users;
using RoadRangerBackEnd.Data.Cars;
using RoadRangerBackEnd.Data.Images;

namespace RoadRangerBackEnd.Search
{
    public class CapturedCarFinder : ICapturedCarFinder
    {
        private readonly IUserData userData = new UserMemoryData();//UserFileSystem.GetInstance();
        private ICarData carData = new CarMemoryData();//new CarFileSystem();
        private IImageData imageData = new ImageMemoryData();//new ImageFileSystem();

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

        public List<CapturedCar> FindAll()
        {
            List<Car> cars = carData.FindAll();
            List<Image> images = imageData.FindAll();

            IEnumerable<CapturedCar> capturedCars = from car in cars
                                                    join image in images on car.Id equals image.CarId
                                                    select new CapturedCar(car, image);
            return capturedCars.ToList();
        }
    }
}