using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;

namespace PhysicsTests.Units
{
    [TestClass]
    public class AngleClassTest
    {
        [TestMethod]
        public void AnglesAreTrimmedToCorrectRange()
        {
            var angleSets = new Dictionary<double, double> { { 90, 90 }, { 27, 27 }, { -10, 350 }, {-50, 310}, { 720, 0}, { 828, 108}, { 4176, 216}, {0 , 0}, {-360, 0}, {-480, 240}, {-2088, 72} };

            foreach (var angleSet in angleSets)
            {
                var angle = Angle.FromDegrees(angleSet.Key);
                Assert.AreEqual(angleSet.Value, angle.Degree);
            }
        }

        [TestMethod]
        public void DegreeCanBeConvertedIntoRadian()
        {
            var angleSets = new Dictionary<double, double> { {-90, 3 * Math.PI / 2}, {30, Math.PI / 6}, { 60, Math.PI / 3 }, { 90, Math.PI / 2 }, {450, Math.PI / 2}, {150, 5 * Math.PI / 6}, {240, 4 * Math.PI / 3}, {315, 7 * Math.PI / 4} };

            foreach (var angleSet in angleSets)
            {
                var angle = Angle.FromDegrees(angleSet.Key);
                Assert.AreEqual(angleSet.Value, angle.Radian);
            }
        }

        [TestMethod]
        public void RadianCanBeConvertedIntoDegree()
        {
            var angleSets = new Dictionary<double, double> { { 30, Math.PI / 6 }, { 60, Math.PI / 3 }, { 90, Math.PI / 2 }, { 150, 5 * Math.PI / 6 }, { 240, 4 * Math.PI / 3 }, { 315, 7 * Math.PI / 4 } };


            foreach (var angleSet in angleSets)
            {
                var angle = Angle.FromRadian(angleSet.Value);
                Assert.AreEqual(angleSet.Key, Math.Round(angle.Degree));
            }
        }
    }
}