using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Cars;
using Models.Images;
using Services.Statistic.Statistics;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class StolenDatesStatisticTest
    {
        [TestMethod]
        public void TestGet()
        {
            CarDateStatistic list = new CarDateStatistic();

            List<CapturedCar> cars = new List<CapturedCar>();
            Image image1 = new Image(3, 7, 1540385152, "wrong");
            Car car1 = new Car(7, 1, "GHM497", "blue", "suzuki", "suzuki_jimny", "sedan-compact", "2005-2009", false, CarStatus.NOT_STOLEN);
            Image image2 = new Image(3, 7, 1540385152, "wrong");
            Car car2 = new Car(7, 1, "GHM497", "blue", "suzuki", "suzuki_jimny", "sedan-compact", "2005-2009", false, CarStatus.NOT_STOLEN);
            cars.Add(new CapturedCar(car1, image1));
            cars.Add(new CapturedCar(car2, image2));

            list.Get(cars, CarStatus.NOT_STOLEN);
        }
    }
}
