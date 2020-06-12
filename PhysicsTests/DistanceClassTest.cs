using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics.Units;

namespace PhysicsTests
{
    [TestClass]
    public class DistanceClassTest
    {
        [TestMethod]
        public void DistanceXAndYCalculatedCorrectly1()
        {
            var dist = new Distance(Angle.FromDegrees(21.7), 2.7);
            var xAndY = dist.CalculateXAndY();

            Assert.AreEqual(1.0, xAndY.X,0.01);
            Assert.AreEqual(2.5, xAndY.Y, 0.01);
        }

        [TestMethod]
        public void DistanceXAndYCalculatedCorrectly2()
        {
            var dist = new Distance(Angle.FromDegrees(143.1), 2.5);
            var xAndY = dist.CalculateXAndY();

            Assert.AreEqual(1.5, xAndY.X, 0.01);
            Assert.AreEqual(-2.0, xAndY.Y, 0.01);
        }

        [TestMethod]
        public void DistanceXAndYCalculatedCorrectly3()
        {
            var dist = new Distance(Angle.FromDegrees(225), Math.Sqrt(2));
            var xAndY = dist.CalculateXAndY();

            Assert.AreEqual(-1, xAndY.X, 0.00001);
            Assert.AreEqual(-1, xAndY.Y, 0.00001);
        }

        [TestMethod]
        public void DistanceXAndYCalculatedCorrectly4()
        {
            var dist = new Distance(Angle.FromDegrees(309), 3.1);
            var xAndY = dist.CalculateXAndY();

            Assert.AreEqual(-2.40, xAndY.X, 0.01);
            Assert.AreEqual(1.95, xAndY.Y, 0.01);
        }

        [TestMethod]
        public void DistanceXAndYCalculatedCorrectly5()
        {
            var dist = new Distance(Angle.FromDegrees(0), 0);
            var xAndY = dist.CalculateXAndY();

            Assert.AreEqual(0, xAndY.X);
            Assert.AreEqual(0, xAndY.Y);
        }

        [TestMethod]
        public void DistanceXAndYCalculatedCorrectly6()
        {
            var dist = new Distance(Angle.FromDegrees(90), 5);
            var xAndY = dist.CalculateXAndY();

            Assert.AreEqual(5, xAndY.X, 0.001);
            Assert.AreEqual(0, xAndY.Y, 0.001);
        }
    }
}
