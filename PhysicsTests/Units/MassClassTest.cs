using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;

namespace PhysicsTests.Units
{
    [TestClass]
    public class MassClassTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTheTest()
        {
            var mass = new Mass(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MassCannotBeNegative()
        {
            var mass = new Mass(-1);
        }

        [TestMethod]
        public void MathAdditionWorks()
        {
            Assert.AreEqual(20, (new Mass(10) + new Mass(10)).Value);
            Assert.AreEqual(7, (new Mass(3.5) + new Mass(3.5)).Value);
            Assert.AreEqual(10010.5, (new Mass(10000.5) + new Mass(10)).Value);
        }

        [TestMethod]
        public void MathSubtractionWorks()
        {
            Assert.AreEqual(1, (new Mass(11) - new Mass(10)).Value);
            Assert.AreEqual(3, (new Mass(5) - new Mass(2)).Value);
            Assert.AreEqual(9990.5, (new Mass(10000.5) - new Mass(10)).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MathSubtractionCannotResultToZero()
        {
            var diff = new Mass(10) - new Mass(10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MathSubtractionCannotResultNegative()
        {
            var diff = new Mass(10) - new Mass(11);
        }
    }
}