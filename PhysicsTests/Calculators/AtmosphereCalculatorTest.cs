using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics.Calculator;
using SpaceFlight.Physics.Units;

namespace PhysicsTests.Calculators
{
    [TestClass]
    public class AtmosphereCalculatorTest
    {
        [TestMethod]
        public void AirDensityCalculatedCorrectly1()
        {
            Assert.AreEqual(0,AtmosphereCalculator.CalculateAirDensityAtAltitude(-100));
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly2()
        {
            Assert.AreEqual(1.225, AtmosphereCalculator.CalculateAirDensityAtAltitude(0));
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly3()
        {
            Assert.AreEqual(1.112, AtmosphereCalculator.CalculateAirDensityAtAltitude(1000));
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly4()
        {
            Assert.AreEqual(1.007, AtmosphereCalculator.CalculateAirDensityAtAltitude(2500));
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly5()
        {
            Assert.AreEqual(0.4135, AtmosphereCalculator.CalculateAirDensityAtAltitude(12500));
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly6()
        {
            Assert.AreEqual(0.01841, AtmosphereCalculator.CalculateAirDensityAtAltitude(35000));
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly7()
        {
            Assert.AreEqual(0.0003097, AtmosphereCalculator.CalculateAirDensityAtAltitude(62100.12312312));
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly8()
        {
            Assert.AreEqual(0, AtmosphereCalculator.CalculateAirDensityAtAltitude(90000));
        }
    }
}
