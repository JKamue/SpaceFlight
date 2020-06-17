using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics.Other;
using SpaceFlight.Physics.Units;

namespace PhysicsTests
{
    [TestClass]
    public class DragPropertiesTest
    {
        [TestMethod]
        public void AreaIsCalculatedCorrectly1()
        {
            var p = new DragProperties(0.25, 0.41, 10, 100);
            Assert.AreEqual(10, p.GetArea(Angle.FromDegrees(0)));
        }

        [TestMethod]
        public void AreaIsCalculatedCorrectly2()
        {
            var p = new DragProperties(0.25, 0.41, 10, 100);
            Assert.AreEqual(100, p.GetArea(Angle.FromDegrees(90)));
        }

        [TestMethod]
        public void AreaIsCalculatedCorrectly3()
        {
            var p = new DragProperties(0.25, 0.41, 10, 100);
            Assert.AreEqual(10, p.GetArea(Angle.FromDegrees(180)));
        }

        [TestMethod]
        public void AreaIsCalculatedCorrectly4()
        {
            var p = new DragProperties(0.25, 0.41, 10, 100);
            Assert.AreEqual(100, p.GetArea(Angle.FromDegrees(270)));
        }

        [TestMethod]
        public void AreaIsCalculatedCorrectly5()
        {
            var p = new DragProperties(0.25, 0.41, 10, 100);
            Assert.AreEqual(55, p.GetArea(Angle.FromDegrees(45)), 0.001);
        }

        [TestMethod]
        public void AreaIsCalculatedCorrectly6()
        {
            var p = new DragProperties(0.25, 0.41, 10, 100);
            Assert.AreEqual(55, p.GetArea(Angle.FromDegrees(135)), 0.001);
        }

        [TestMethod]
        public void AreaIsCalculatedCorrectly7()
        {
            var p = new DragProperties(0.25, 0.41, 10, 100);
            Assert.AreEqual(55, p.GetArea(Angle.FromDegrees(315)), 0.001);
        }

        [TestMethod]
        public void DragCoefficientIsCorrectly1()
        {
            var p = new DragProperties(0.25, 0.41, 10, 100);
            Assert.AreEqual(0.25, p.GetDragCoefficient(Angle.FromDegrees(0)), 0.001);
        }

        [TestMethod]
        public void DragCoefficientIsCorrectly2()
        {
            var p = new DragProperties(0.25, 0.41, 10, 100);
            Assert.AreEqual(0.41, p.GetDragCoefficient(Angle.FromDegrees(90)), 0.001);
        }

        [TestMethod]
        public void DragCoefficientIsCorrectly3()
        {
            var p = new DragProperties(0.25, 0.41, 10, 100);
            Assert.AreEqual(0.33, p.GetDragCoefficient(Angle.FromDegrees(315)), 0.001);
        }
    }
}
