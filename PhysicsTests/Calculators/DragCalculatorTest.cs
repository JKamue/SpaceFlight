using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Calculator;
using SpaceFlight.Physics.Units;

namespace PhysicsTests.Calculators
{
    [TestClass]
    public class DragCalculatorTest
    {
        [TestMethod]
        public void DragIsCalculatedCorrectly()
        {
            var zeroAngle = Angle.FromDegrees(0);
            var cd = 0.25;
            var p = AtmosphereCalculator.CalculateAirDensityAtAltitude(5000);
            var s = new Speed(zeroAngle, 500);
            var area = 21;
            var f = DragCalculator.CalculateDrag(zeroAngle, cd, p, s, area);
            Assert.AreEqual(483262.5, f.Value, 0.1);
        }
    }
}
