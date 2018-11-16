using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadRangerBackEnd.Cars;
using RoadRangerBackEnd.Score;

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

            Evaluation evaluation = new Evaluation();
            int score = evaluation.Evaluate(car);

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

            Evaluation evaluation = new Evaluation();
            int score = evaluation.Evaluate(car);

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

            Evaluation evaluation = Evaluation.Instance;
            int score = evaluation.Evaluate(car);

            System.Console.WriteLine("NotStolen status score: " + score);
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

            Evaluation evaluation = Evaluation.Instance;
            int score = evaluation.Evaluate(car);

            System.Console.WriteLine("Unknown status score: " + score);
            Assert.IsTrue(expectedScore == score);
        }
    }
}
