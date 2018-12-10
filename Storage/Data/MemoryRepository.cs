using Models.Cars;
using Models.Images;
using Models.Users;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace Storage.Data
{
    public class MemoryRepository
    {
        public static List<Car> cars = new List<Car>();
        public static List<Image> images = new List<Image>();
        public static List<User> users = new List<User>();
        private static MemoryRepository instance;

        public static MemoryRepository GetInstance() // jei jau yra toks objektas ji grazina, jei ne sukuria
        {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                instance = new MemoryRepository();
                Initialize();
                return instance;
            }
        }

        private static void Initialize()
        {
            Image img1 = ImageFactory.GetInstance().CreateImage(0, 0, 1541321310, "", new Position(54.72911, 25.26275));
            Image img2 = ImageFactory.GetInstance().CreateImage(1, 1, 1541321310, null,new Position(54.73148, 25.2583));
            Image img3 = ImageFactory.GetInstance().CreateImage(2, 2, 1541321310, null, new Position(54.73412, 25.260056));
            Image img4 = ImageFactory.GetInstance().CreateImage(3, 3, 1541321310, null,new Position(54.732342, 25.260571));

            images.Add(img1);
            images.Add(img2);
            images.Add(img3);
            images.Add(img4);

            Car car1 = CarFactory.GetInstance().CreateCar(0, 0, "AAA000", "black", "volvo", "volvo", "sedan", "2010-2014", CarStatus.NOT_STOLEN, true);
            Car car2 = CarFactory.GetInstance().CreateCar(1, 0, "AAA111", "white", "BMW", "BMW", "sedan", "2010-2014", CarStatus.STOLEN, true);
            Car car3 = CarFactory.GetInstance().CreateCar(2, 1, "AAA222", "red", "audi", "audi", "sedan", "2010-2014", CarStatus.STOLEN_PLATE, true);
            Car car4 = CarFactory.GetInstance().CreateCar(3, 1, "AAA333", "green", "zigul", "zigul", "sedan", "2010-2014", CarStatus.NOT_STOLEN, true);

            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            cars.Add(car4);

            var user1 = new User
            {
                Id = 0,
                Username = "user1",
                Password = "HashedPassword",
                Score = 0
            };

            var user2 = new User
            {
                Id = 1,
                Username = "user2",
                Password = "HashedPassword",
                Score = 100
            };

            var user3 = new User
            {
                Id = 2,
                Username = "user3",
                Password = "HashedPassword",
                Score = 1200
            };

            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
        }
    }
}
