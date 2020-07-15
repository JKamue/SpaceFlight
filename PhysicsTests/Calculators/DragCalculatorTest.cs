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
            var p = AtmosphereCalculator.CalculateAirDensityAtAltitude(5000);
            var s = new Speed(zeroAngle, 500);
            var f = DragCalculator.CalculateDrag(zeroAngle, 0.25, p, s, 21);
            Assert.AreEqual(476787.3, f.Value, 0.1);
        }
    }
}
