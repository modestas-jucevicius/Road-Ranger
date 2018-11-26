using Models.Cars;
using Models.Images;
using System.Collections.Generic;

namespace Storage.Data
{
    public class MemoryRepository
    {
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
            Image img1 = ImageFactory.GetInstance().CreateImage(0, 0, 1541321310, new byte[0]);
            Image img2 = ImageFactory.GetInstance().CreateImage(1, 1, 1541321310, new byte[0]);
            Image img3 = ImageFactory.GetInstance().CreateImage(2, 2, 1541321310, new byte[0]);
            Image img4 = ImageFactory.GetInstance().CreateImage(3, 3, 1541321310, new byte[0]);

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
        }
    }
}
