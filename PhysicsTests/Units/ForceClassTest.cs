using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;

namespace PhysicsTests.Units
{
    [TestClass]
    public class ForceClassTest
    {
        [TestMethod]
        public void AccelerationCalculatedCorrectly()
        {
            var force = new Force(Angle.FromDegrees(0), 15);
            var acceleration = force.GetAcceleration(new Mass(5));
            Assert.AreEqual(3, acceleration.Value);
        }

        [TestMethod]
        public void MassCalculatedCorrectly2()
        {
            var force = new Force(Angle.FromDegrees(0), 15);
            var mass = force.GetMass(new Acceleration(Angle.FromDegrees(0), 5));
            Assert.AreEqual(3, mass.Value);
        }

        public void ForcesWithSameAngleAreAddedCorrectly(Force f1, Force f2, Force expected)
        {
            var resultingForce = f1 + f2;

            Assert.AreEqual(Math.Round(expected.Value,1), Math.Round(resultingForce.Value, 1));
            Assert.AreEqual(Math.Round(expected.Angle.Degree), Math.Round(resultingForce.Angle.Degree));
        }
    }
}
