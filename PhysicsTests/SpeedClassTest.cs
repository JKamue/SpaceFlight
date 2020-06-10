using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics.Units;

namespace PhysicsTests
{
    [TestClass]
    public class SpeedClassTest
    {
        [TestMethod]
        public void SpeedIsAddable()
        {
            var s1 = new Speed(30);
            var s2 = new Speed(10);
            Assert.AreEqual(40, (s1 + s2).Value);
        }

        [TestMethod]
        public void SpeedIsSubtractable()
        {
            var s1 = new Speed(30);
            var s2 = new Speed(10);
            Assert.AreEqual(20, (s1 - s2).Value);
        }

        [TestMethod]
        public void SpeedCanBeConvertedToDistance()
        {
            var s = new Speed(30);
            var span = TimeSpan.FromSeconds(0.3);
            Assert.AreEqual(9, s.GetDistance(span));
        }
    }
}