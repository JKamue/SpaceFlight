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
            var acc = new Acceleration(Angle.FromDegrees(20),30 );
            var span = TimeSpan.FromSeconds(20);
            Assert.AreEqual(600, acc.GetSpeed(span).Value);
        }

        [TestMethod]
        public void SpeedIsCalculatedCorrectly2()
        {
            var acc = new Acceleration(Angle.FromDegrees(20), 0);
            var span = TimeSpan.FromSeconds(20);
            Assert.AreEqual(0, acc.GetSpeed(span).Value);
        }

        [TestMethod]
        public void SpeedIsCalculatedCorrectly3()
        {
            var acc = new Acceleration(Angle.FromDegrees(20), 1);
            var span = TimeSpan.FromSeconds(0.2);
            Assert.AreEqual(0.2, acc.GetSpeed(span).Value);
        }
    }
}
