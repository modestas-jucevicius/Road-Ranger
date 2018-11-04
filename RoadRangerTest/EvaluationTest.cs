using Microsoft.VisualStudio.TestTools.UnitTesting;
<<<<<<< HEAD
using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Score;
=======
using Road_rangerVS.OutsideAPI;
using Road_rangerVS.Recognition;
using Road_rangerVS.Score;
using Road_rangerVS.Cars;
<<<<<<< HEAD
>>>>>>> 14143fd53e9df87f9d61baa2872c61231ac6452d
=======
>>>>>>> 14143fd53e9df87f9d61baa2872c61231ac6452d

namespace RoadRangerTest
{
    [TestClass]
    public class EvaluationTest
    {
        [TestMethod]
        public void TestEvaluateStolenCar()
        {
            int id = 1;
            int userId = 1;
            string licensePlate = "AAA000";
            string colorName = "white";
            string makeName = "fiat";
            string model = "500";
            string bodyType = "hatchback";
            string year = "2018";
            CarStatus status = CarStatus.STOLEN;
            bool isReported = true;
            Car car = new Car(id, userId, licensePlate, colorName, makeName, model, bodyType, year, isReported, status);
            double expectedScore = 2500;

            int score = Evaluation.Evaluate(car);

            Assert.IsTrue(expectedScore == score);
        }

        [TestMethod]
        public void TestEvaluateStolenPlate()
        {
            int id = 1;
            int userId = 1;
            string licensePlate = "AAA000";
            string colorName = "white";
            string makeName = "fiat";
            string model = "500";
            string bodyType = "hatchback";
            string year = "2018";
            CarStatus status = CarStatus.STOLEN_PLATE;
            bool isReported = true;
            Car car = new Car(id, userId, licensePlate, colorName, makeName, model, bodyType, year, isReported, status);
            double expectedScore = 1500;

            int score = Evaluation.Evaluate(car);

            Assert.IsTrue(expectedScore == score);
        }

        [TestMethod]
        public void TestEvaluateNotStolenCar()
        {
            int id = 1;
            int userId = 1;
            string licensePlate = "AAA000";
            string colorName = "white";
            string makeName = "fiat";
            string model = "500";
            string bodyType = "hatchback";
            string year = "2018";
            CarStatus status = CarStatus.NOT_STOLEN;
            bool isReported = true;
            Car car = new Car(id, userId, licensePlate, colorName, makeName, model, bodyType, year, isReported, status);
            double expectedScore = 10;

            int score = Evaluation.Evaluate(car);

            Assert.IsTrue(expectedScore == score);
        }

        [TestMethod]
        public void TestEvaluateUnknownStatusCar()
        {
            int id = 1;
            int userId = 1;
            string licensePlate = "AAA000";
            string colorName = "white";
            string makeName = "fiat";
            string model = "500";
            string bodyType = "hatchback";
            string year = "2018";
            CarStatus status = CarStatus.UNKNOWN;
            bool isReported = true;
            Car car = new Car(id, userId, licensePlate, colorName, makeName, model, bodyType, year, isReported, status);
            double expectedScore = 0;

            int score = Evaluation.Evaluate(car);

            Assert.IsTrue(expectedScore == score);
        }
    }
}
