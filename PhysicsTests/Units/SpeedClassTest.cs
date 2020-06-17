using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics.Units;

namespace PhysicsTests.Units
{
    [TestClass]
    public class SpeedClassTest
    {
        [TestMethod]
        public void SpeedCanBeConvertedToDistance1()
        {
            var s = new Speed(Angle.FromDegrees(20), 30);
            var span = TimeSpan.FromSeconds(0.3);
            Assert.AreEqual(9, s.GetDistance(span).Value);
        }

        [TestMethod]
        public void SpeedCanBeConvertedToDistance2()
        {
            var s = new Speed(Angle.FromDegrees(20), 30);
            var span = TimeSpan.FromSeconds(0.3);
            Assert.AreEqual(9, s.GetDistance(span).Value);
        }
    }
}