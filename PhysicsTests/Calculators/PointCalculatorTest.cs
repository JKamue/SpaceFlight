using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics.Calculator;
using SpaceFlight.Physics.Units;

namespace PhysicsTests.Calculators
{
    [TestClass]
    public class PointCalculatorTest
    {

        [TestMethod]
        public void AngleCalculatedCorrectly1()
        {
            var p1 = new PointF(5,5);
            var p2 = new Point(5,10);
            Assert.AreEqual(0, PointCalculator.CalculateAngle(p1, p2).Degree);
        }

        [TestMethod]
        public void AngleCalculatedCorrectly2()
        {
            var p1 = new PointF(5, 5);
            var p2 = new Point(6, 6);
            Assert.AreEqual(45, PointCalculator.CalculateAngle(p1, p2).Degree);
        }

        [TestMethod]
        public void AngleCalculatedCorrectly3()
        {
            var p1 = new PointF(5, 5);
            var p2 = new Point(7, 5);
            Assert.AreEqual(90, PointCalculator.CalculateAngle(p1, p2).Degree);
        }

        [TestMethod]
        public void AngleCalculatedCorrectly4()
        {
            var p1 = new PointF(5, 5);
            var p2 = new Point(7, 3);
            Assert.AreEqual(135, PointCalculator.CalculateAngle(p1, p2).Degree);
        }

        [TestMethod]
        public void AngleCalculatedCorrectly5()
        {
            var p1 = new PointF(5, 5);
            var p2 = new Point(5, 3);
            Assert.AreEqual(180, PointCalculator.CalculateAngle(p1, p2).Degree);
        }

        [TestMethod]
        public void AngleCalculatedCorrectly6()
        {
            var p1 = new PointF(5, 5);
            var p2 = new Point(3, 3);
            Assert.AreEqual(225, PointCalculator.CalculateAngle(p1, p2).Degree);
        }

        [TestMethod]
        public void AngleCalculatedCorrectly7()
        {
            var p1 = new PointF(5, 5);
            var p2 = new Point(3, 5);
            Assert.AreEqual(270, PointCalculator.CalculateAngle(p1, p2).Degree);
        }

        [TestMethod]
        public void AngleCalculatedCorrectly8()
        {
            var p1 = new PointF(5, 5);
            var p2 = new Point(3, 7);
            Assert.AreEqual(315, PointCalculator.CalculateAngle(p1, p2).Degree);
        }

        [TestMethod]
        public void DistanceCalculatedCorrectly1()
        {
            var p1 = new PointF(10, 8);
            var p2 = new Point(14, 9);
            Assert.AreEqual(4.1, PointCalculator.Distance(p1,p2), 0.1);
        }

        [TestMethod]
        public void DistanceCalculatedCorrectly2()
        {
            var p1 = new PointF(10, 8);
            var p2 = new Point(13, 4);
            Assert.AreEqual(5, PointCalculator.Distance(p1, p2), 0.1);
        }

        [TestMethod]
        public void DistanceCalculatedCorrectly3()
        {
            var p1 = new PointF(10, 8);
            var p2 = new Point(5, 3);
            Assert.AreEqual(7, PointCalculator.Distance(p1, p2), 0.1);
        }

        [TestMethod]
        public void DistanceCalculatedCorrectly4()
        {
            var p1 = new PointF(0, 0);
            var p2 = new Point(0, 0);
            Assert.AreEqual(0, PointCalculator.Distance(p1, p2), 0.1);
        }

        [TestMethod]
        public void DistanceCalculatedCorrectly5()
        {
            var p1 = new PointF(0, 0);
            var p2 = new Point(2, 0);
            Assert.AreEqual(2, PointCalculator.Distance(p1, p2), 0.1);
        }

        [TestMethod]
        public void VectorXAndYCalculatedCorrectly1()
        {
            var v = new Vector(Angle.FromDegrees(0), 100);
            Assert.AreEqual(0, PointCalculator.GetVectorX(v));
            Assert.AreEqual(100, PointCalculator.GetVectorY(v));
        }

        [TestMethod]
        public void VectorXAndYCalculatedCorrectly2()
        {
            var v = new Vector(Angle.FromDegrees(30), 5);
            Assert.AreEqual(2.5, PointCalculator.GetVectorX(v), 0.1);
            Assert.AreEqual(4.3, PointCalculator.GetVectorY(v), 0.1);
        }

        [TestMethod]
        public void VectorXAndYCalculatedCorrectly3()
        {
            var v = new Vector(Angle.FromDegrees(70), 4.3);
            Assert.AreEqual(4, PointCalculator.GetVectorX(v), 0.1);
            Assert.AreEqual(1.5, PointCalculator.GetVectorY(v), 0.1);
        }

        [TestMethod]
        public void VectorXAndYCalculatedCorrectly4()
        {
            var v = new Vector(Angle.FromDegrees(130), 3.9);
            Assert.AreEqual(3, PointCalculator.GetVectorX(v), 0.1);
            Assert.AreEqual(-2.5, PointCalculator.GetVectorY(v), 0.1);
        }

        [TestMethod]
        public void VectorXAndYCalculatedCorrectly5()
        {
            var v = new Vector(Angle.FromDegrees(180), 4);
            Assert.AreEqual(0, PointCalculator.GetVectorX(v), 0.1);
            Assert.AreEqual(-4, PointCalculator.GetVectorY(v), 0.1);
        }

        [TestMethod]
        public void VectorXAndYCalculatedCorrectly6()
        {
            var v = new Vector(Angle.FromDegrees(250), 4.3);
            Assert.AreEqual(-4, PointCalculator.GetVectorX(v), 0.1);
            Assert.AreEqual(-1.5, PointCalculator.GetVectorY(v), 0.1);
        }


        [TestMethod]
        public void VectorXAndYCalculatedCorrectly7()
        {
            var v = new Vector(Angle.FromDegrees(320), 3.9);
            Assert.AreEqual(-2.5, PointCalculator.GetVectorX(v), 0.1);
            Assert.AreEqual(3, PointCalculator.GetVectorY(v), 0.1);
        }
    }
}
