using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Images;
using RoadRangerBackEnd.Users;
using System.Collections.Generic;

namespace RoadRangerBackEnd.Data
{
    public class MemoryRepository
    {
        public static List<User> users = new List<User>();
        public static List<Car> cars = new List<Car>();
        public static List<Image> images = new List<Image>();
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
            Image img1 = new Image(0, 0, 1541321310, new byte[0]);
            Image img2 = new Image(1, 1, 1541321310, new byte[0]);
            Image img3 = new Image(2, 2, 1541321310, new byte[0]);
            Image img4 = new Image(3, 3, 1541321310, new byte[0]);

            images.Add(img1);
            images.Add(img2);
            images.Add(img3);
            images.Add(img4);

            User usr1 = new User(0, "user1", "pass1", "User1", 500);
            User usr2 = new User(1, "user1", "pass1", "User1", 500);
            User usr3 = new User(2, "user1", "pass1", "User1", 500);

            users.Add(usr1);
            users.Add(usr2);
            users.Add(usr3);

            Car car1 = new Car(0, 0, "AAA000", "black", "volvo", "volvo", "sedan", "2010-2014", true, CarStatus.NOT_STOLEN);
            Car car2 = new Car(1, 0, "AAA111", "white", "BMW", "BMW", "sedan", "2010-2014", true, CarStatus.STOLEN);
            Car car3 = new Car(2, 1, "AAA222", "red", "audi", "audi", "sedan", "2010-2014", true, CarStatus.STOLEN_PLATE);
            Car car4 = new Car(3, 1, "AAA333", "green", "zigul", "zigul", "sedan", "2010-2014", true, CarStatus.NOT_STOLEN);

            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            cars.Add(car4);
        }
    }
}
