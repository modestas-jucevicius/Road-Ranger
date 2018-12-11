using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileApp.Services.Validation;

namespace Test
{
    [TestClass]
    public class LicensePlateValidatorTest
    {
        [TestMethod]
        public void TestIsValidTrue()
        {
            LicensePlateValidator validator = new LicensePlateValidator();
            string plate = "AAA000";

            Boolean match = validator.IsValid(plate);

            Assert.IsFalse(!match);
        }

        [TestMethod]
        public void TestIsValidFalse()
        {
            LicensePlateValidator validator = new LicensePlateValidator();
            string plate = "A0A000";

            Boolean match = validator.IsValid(plate);

            Assert.IsFalse(match);
        }

        [TestMethod]
        public void TestIsValidTrailerFormat()
        {
            LicensePlateValidator validator = new LicensePlateValidator();

            string plate = "AA000";
            Boolean match = validator.IsValid(plate);
            Assert.IsFalse(!match);

            plate = "0A000";
            match = validator.IsValid(plate);
            Assert.IsFalse(match);
        }
    }
}
