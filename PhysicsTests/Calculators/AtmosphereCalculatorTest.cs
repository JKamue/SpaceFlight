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
            Assert.AreEqual(1.2496, AtmosphereCalculator.CalculateAirDensityAtAltitude(0), 0.001);
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly3()
        {
            Assert.AreEqual(1.121, AtmosphereCalculator.CalculateAirDensityAtAltitude(1000), 0.001);
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly4()
        {
            Assert.AreEqual(0.9528, AtmosphereCalculator.CalculateAirDensityAtAltitude(2500), 0.001);
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly5()
        {
            Assert.AreEqual(0.283, AtmosphereCalculator.CalculateAirDensityAtAltitude(12500), 0.001);
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly6()
        {
            Assert.AreEqual(0.00859, AtmosphereCalculator.CalculateAirDensityAtAltitude(35000), 0.00001);
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly7()
        {
            Assert.AreEqual(0.00022, AtmosphereCalculator.CalculateAirDensityAtAltitude(62100.12312312), 0.00001);
        }

        [TestMethod]
        public void AirDensityCalculatedCorrectly8()
        {
            Assert.AreEqual(0, AtmosphereCalculator.CalculateAirDensityAtAltitude(90000));
        }
    }
}
