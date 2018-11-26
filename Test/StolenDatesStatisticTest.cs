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
            Image image1 = ImageFactory.GetInstance().CreateImage(3, 7, 1540385152, "wrong");
            Car car1 = CarFactory.GetInstance().CreateCar(7, 1, "GHM497", "blue", "suzuki", "suzuki_jimny", "sedan-compact", "2005-2009", CarStatus.NOT_STOLEN, false);
            Image image2 = ImageFactory.GetInstance().CreateImage(3, 7, 1540385152, "wrong");
            Car car2 = CarFactory.GetInstance().CreateCar(7, 1, "GHM497", "blue", "suzuki", "suzuki_jimny", "sedan-compact", "2005-2009", CarStatus.NOT_STOLEN, false);
            cars.Add(CarFactory.GetInstance().CreateCapturedCar(car1, image1));
            cars.Add(CarFactory.GetInstance().CreateCapturedCar(car2, image2));

            list.Get(cars, CarStatus.NOT_STOLEN);
        }
    }
}
