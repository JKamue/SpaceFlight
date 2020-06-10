using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics.Units;

namespace PhysicsTests
{
    [TestClass]
    public class AccelerationClassTest
    {
        [TestMethod]
        public void SpeedIsCalculatedCorrectly1()
        {
            var acc = new Acceleration(30);
            var span = TimeSpan.FromSeconds(20);
            Assert.AreEqual(600, acc.GetSpeed(span).Value);
        }

        [TestMethod]
        public void SpeedIsCalculatedCorrectly2()
        {
            var acc = new Acceleration(0);
            var span = TimeSpan.FromSeconds(20);
            Assert.AreEqual(0, acc.GetSpeed(span).Value);
        }

        [TestMethod]
        public void SpeedIsCalculatedCorrectly3()
        {
            var acc = new Acceleration(1);
            var span = TimeSpan.FromSeconds(0.2);
            Assert.AreEqual(0.2, acc.GetSpeed(span).Value);
        }

        [TestMethod]
        public void AccelerationSumsCorrectly()
        {
            var acc1 = new Acceleration(1);
            var acc2 = new Acceleration(3);
            var acc3 = new Acceleration(10);
            Assert.AreEqual(14, (acc1 + acc2 + acc3).Value);
        }

        [TestMethod]
        public void AccelerationSubtractsCorrectly()
        {
            var acc1 = new Acceleration(1);
            var acc2 = new Acceleration(3);
            var acc3 = new Acceleration(10);
            Assert.AreEqual(6, (acc3 - acc2 - acc1).Value);
        }
    }
}
