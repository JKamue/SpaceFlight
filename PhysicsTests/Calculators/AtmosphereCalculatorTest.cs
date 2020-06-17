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
        public void AtmosphericPressureCalculatedCorrectly1()
        {
            Assert.AreEqual(101325,AtmosphereCalculator.CalculatePressureAtAltitude(0));
        }

        [TestMethod]
        public void AtmosphericPressureCalculatedCorrectly2()
        {
            Assert.AreEqual(95443.78, AtmosphereCalculator.CalculatePressureAtAltitude(500), 0.01);
        }

        [TestMethod]
        public void AtmosphericPressureCalculatedCorrectly3()
        {
            Assert.AreEqual(89810.56, AtmosphereCalculator.CalculatePressureAtAltitude(1000), 0.01);
        }

        [TestMethod]
        public void AtmosphericPressureCalculatedCorrectly4()
        {
            Assert.AreEqual(52918.34, AtmosphereCalculator.CalculatePressureAtAltitude(5000), 0.01);
        }

        [TestMethod]
        public void AtmosphericPressureCalculatedCorrectly5()
        {
            Assert.AreEqual(23820.29, AtmosphereCalculator.CalculatePressureAtAltitude(10000), 0.01);
        }

        [TestMethod]
        public void AtmosphericPressureCalculatedCorrectly6()
        {
            Assert.AreEqual(1930.14, AtmosphereCalculator.CalculatePressureAtAltitude(20000), 0.01);
        }

        [TestMethod]
        public void AtmosphericPressureCalculatedCorrectly7()
        {
            Assert.AreEqual(0.1038, AtmosphereCalculator.CalculatePressureAtAltitude(28950), 0.0001);
        }

        [TestMethod]
        public void AtmosphericPressureCalculatedCorrectly8()
        {
            Assert.AreEqual(0.1, AtmosphereCalculator.CalculatePressureAtAltitude(28951));
        }

        [TestMethod]
        public void AtmosphericPressureCalculatedCorrectly10()
        {
            Assert.AreEqual(0.1, AtmosphereCalculator.CalculatePressureAtAltitude(80000));
        }

        [TestMethod]
        public void AtmosphericPressureCalculatedCorrectly11()
        {
            Assert.AreEqual(0, AtmosphereCalculator.CalculatePressureAtAltitude(80001));
        }

        [TestMethod]
        public void AtmosphericPressureCalculatedCorrectly12()
        {
            Assert.AreEqual(0, AtmosphereCalculator.CalculatePressureAtAltitude(-100));
        }


    }
}
