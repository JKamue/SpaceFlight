using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;

namespace PhysicsTests
{
    [TestClass]
    public class ForceClassTest
    {

        [TestMethod]
        public void ForcesAddTest1()
        {
            var f1 = new Force(Angle.FromDegrees(0), 6);
            var f2 = new Force(Angle.FromDegrees(135), 4);
            var resultingForce = new Force(Angle.FromDegrees(42), 4.2);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

        [TestMethod]
        public void ForcesAddTest2()
        {
            var f1 = new Force(Angle.FromDegrees(45), 5);
            var f2 = new Force(Angle.FromDegrees(270), 3);
            var resultingForce = new Force(Angle.FromDegrees(9), 3.6);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

        [TestMethod]
        public void ForcesAddTest3()
        {
            var f1 = new Force(Angle.FromDegrees(45), 3);
            var f2 = new Force(Angle.FromDegrees(270), 5);
            var resultingForce = new Force(Angle.FromDegrees(306), 3.6);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

        [TestMethod]
        public void ForcesAddTest4()
        {
            var f1 = new Force(Angle.FromDegrees(45), 5);
            var f2 = new Force(Angle.FromDegrees(180), 3);
            var resultingForce = new Force(Angle.FromDegrees(81), 3.6);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

        [TestMethod]
        public void ForcesAddTest5()
        {
            var f1 = new Force(Angle.FromDegrees(45), 5);
            var f2 = new Force(Angle.FromDegrees(45), 3);
            var resultingForce = new Force(Angle.FromDegrees(45), 8);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

        [TestMethod]
        public void ForcesCancelOutTest()
        {
            var f1 = new Force(Angle.FromDegrees(45), 2);
            var f2 = new Force(Angle.FromDegrees(225), 2);
            var resultingForce = new Force(Angle.FromDegrees(0), 0);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

        [TestMethod]
        public void ForcesZeroTest()
        {
            var f1 = new Force(Angle.FromDegrees(0), 0);
            var f2 = new Force(Angle.FromDegrees(0), 0);
            var resultingForce = new Force(Angle.FromDegrees(0), 0);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

        [TestMethod]
        public void OneForceZeroTest1()
        {
            var f1 = new Force(Angle.FromDegrees(0), 0);
            var f2 = new Force(Angle.FromDegrees(25), 10);
            var resultingForce = new Force(Angle.FromDegrees(25), 10);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

        [TestMethod]
        public void OneForceZeroTest2()
        {
            var f1 = new Force(Angle.FromDegrees(68), 0);
            var f2 = new Force(Angle.FromDegrees(120), 10);
            var resultingForce = new Force(Angle.FromDegrees(120), 10);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

        [TestMethod]
        public void ForcesWrongOrderTest1()
        {
            var f2 = new Force(Angle.FromDegrees(0), 6);
            var f1 = new Force(Angle.FromDegrees(135), 4);
            var resultingForce = new Force(Angle.FromDegrees(42), 4.2);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

        [TestMethod]
        public void ForcesWrongOrderTest2()
        {
            var f2 = new Force(Angle.FromDegrees(45), 5);
            var f1 = new Force(Angle.FromDegrees(270), 3);
            var resultingForce = new Force(Angle.FromDegrees(9), 3.6);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

        [TestMethod]
        public void ForcesWrongOrderTest3()
        {
            var f2 = new Force(Angle.FromDegrees(45), 3);
            var f1 = new Force(Angle.FromDegrees(270), 5);
            var resultingForce = new Force(Angle.FromDegrees(306), 3.6);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

        [TestMethod]
        public void ForcesWrongOrderTest4()
        {
            var f2 = new Force(Angle.FromDegrees(45), 5);
            var f1 = new Force(Angle.FromDegrees(180), 3);
            var resultingForce = new Force(Angle.FromDegrees(81), 3.6);

            ForcesWithSameAngleAreAddedCorrectly(f1, f2, resultingForce);
        }

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
            var mass = force.GetMass(new Acceleration(5));
            Assert.AreEqual(3, mass.Value);
        }

        public void ForcesWithSameAngleAreAddedCorrectly(Force f1, Force f2, Force expected)
        {
            var resultingForce = f1 + f2;

            Assert.AreEqual(Math.Round(expected.Value,1), Math.Round(resultingForce.Value, 1));
            Assert.AreEqual(Math.Round(expected.Deg), Math.Round(resultingForce.Deg));
        }
    }
}
