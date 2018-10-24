using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Road_rangerVS.Images;
using Road_rangerVS.Recognition;
using Road_rangerVS.Search;

namespace RoadRangerTest
{
    [TestClass]
    public class CapturedCarFinderTest
    {
        [TestMethod]
        public void TestFindByUserId()
        {
            //Vietoj override'inimo klasėse, kad compare'intų properties, sukūriau string eilutes su jais
            //ir jas compare'inu
            CapturedCarFinder carFinder = new CapturedCarFinder();
            List<CapturedCar> testList = new List<CapturedCar>();
            List<CapturedCar> expect = new List<CapturedCar>();
            int check = 0;
            Image imageTest1 = new Image(3, 7, 1540385152, "C:/Users/pjach/Documents/Road-Ranger/RoadRangerTest/Storage/Images/3.jpg");
            Car carTest1 = new Car(7,1, "GHM497","blue","suzuki","suzuki_jimny","sedan-compact","2005-2009", false, Road_rangerVS.OutsideAPI.CarStatus.NOT_STOLEN);
            Image imageTest2 = new Image(1, 4, 1540384597, "C:/Users/pjach/Documents/Road-Ranger/RoadRangerTest/Storage/Images/1.jpg");
            Car carTest2 = new Car(4,1, "GHM497", "blue", "suzuki", "suzuki_jimny", "sedan-compact", "2005-2009", false, Road_rangerVS.OutsideAPI.CarStatus.NOT_STOLEN);
            expect.Add(new CapturedCar(carTest1, imageTest1));
            expect.Add(new CapturedCar(carTest2, imageTest2));
            testList = carFinder.FindByUserId(1);
            int a = testList.Count;
            Console.WriteLine(a);
            for (int i = 0; i < a; i++)
            {
                string expected = expect[i].Image.Id + " " + expect[i].Image.CarId + " " +
                    expect[i].Image.Timestamp  + " " +
                    expect[i].Id + " " + expect[i].UserId + " " + expect[i].LicensePlate + " " +
                    expect[i].ColorName + " " + expect[i].MakeName + " " + expect[i].Model + " " +
                    expect[i].BodyType + " " + expect[i].Year + " " + expect[i].IsReported + " " +
                    expect[i].Status;
                string test = testList[i].Image.Id + " " + testList[i].Image.CarId + " " +
                    testList[i].Image.Timestamp + " " +
                    testList[i].Id + " " + testList[i].UserId + " " + testList[i].LicensePlate + " " +
                    testList[i].ColorName + " " + testList[i].MakeName + " " + testList[i].Model + " " +
                    testList[i].BodyType + " " + testList[i].Year + " " + testList[i].IsReported + " " +
                    testList[i].Status;
                if (string.Equals(expected, test)) { check++; }
                Console.WriteLine(expected + Environment.NewLine + test + Environment.NewLine);
            }

            Assert.IsTrue(check == a);
        }

        [TestMethod]
        public void TestFindByPlate()
        {
            //Vietoj override'inimo klasėse, kad compare'intų properties, sukūriau string eilutes su jais
            //ir jas compare'inu
            CapturedCarFinder carFinder = new CapturedCarFinder();
            List<CapturedCar> testList = new List<CapturedCar>();
            List<CapturedCar> expect = new List<CapturedCar>();
            int check = 0;
            Image imageTest1 = new Image(0, 0, 1540384526, "C:/Users/pjach/Documents/Road-Ranger/RoadRangerTest/Storage/Images/0.jpg");
            Car carTest1 = new Car(0, 0, "EBO666", "silver-gray", "audi", "audi_a4", "sedan-standard", "2000-2004", false, Road_rangerVS.OutsideAPI.CarStatus.NOT_STOLEN);
            Image imageTest2 = new Image(2, 2, 1540384625, "C:/Users/pjach/Documents/Road-Ranger/RoadRangerTest/Storage/Images/2.jpg");
            Car carTest2 = new Car(2, 0, "EBO666", "silver-gray", "audi", "audi_a4", "sedan-standard", "2000-2004", false, Road_rangerVS.OutsideAPI.CarStatus.NOT_STOLEN);
            expect.Add(new CapturedCar(carTest2, imageTest2));
            expect.Add(new CapturedCar(carTest1, imageTest1));
            testList = carFinder.FindByPlate("EBO666");
            int a = testList.Count;
            Console.WriteLine(a);
            for (int i = 0; i < a; i++)
            {
                string expected = expect[i].Image.Id + " " + expect[i].Image.CarId + " " +
                    expect[i].Image.Timestamp + " " +
                    expect[i].Id + " " + expect[i].UserId + " " + expect[i].LicensePlate + " " +
                    expect[i].ColorName + " " + expect[i].MakeName + " " + expect[i].Model + " " +
                    expect[i].BodyType + " " + expect[i].Year + " " + expect[i].IsReported + " " +
                    expect[i].Status;
                string test = testList[i].Image.Id + " " + testList[i].Image.CarId + " " +
                    testList[i].Image.Timestamp + " " +
                    testList[i].Id + " " + testList[i].UserId + " " + testList[i].LicensePlate + " " +
                    testList[i].ColorName + " " + testList[i].MakeName + " " + testList[i].Model + " " +
                    testList[i].BodyType + " " + testList[i].Year + " " + testList[i].IsReported + " " +
                    testList[i].Status;
                if (string.Equals(expected, test)) { check++; }
                Console.WriteLine(expected + Environment.NewLine + test + Environment.NewLine);
            }

            Assert.IsTrue(check == a);
        }
    }
}
