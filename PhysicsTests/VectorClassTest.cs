using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;

namespace PhysicsTests
{
    [TestClass]
    public class VectorClassTest
    {
        [TestMethod]
        public void VectorsAddTest1()
        {
            var f1 = new Vector(Angle.FromDegrees(0), 6);
            var f2 = new Vector(Angle.FromDegrees(135), 4);
            var resultingVector = new Vector(Angle.FromDegrees(42), 4.2);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void VectorsAddTest2()
        {
            var f1 = new Vector(Angle.FromDegrees(45), 5);
            var f2 = new Vector(Angle.FromDegrees(270), 3);
            var resultingVector = new Vector(Angle.FromDegrees(9), 3.6);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void VectorsAddTest3()
        {
            var f1 = new Vector(Angle.FromDegrees(45), 3);
            var f2 = new Vector(Angle.FromDegrees(270), 5);
            var resultingVector = new Vector(Angle.FromDegrees(306), 3.6);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void VectorsAddTest4()
        {
            var f1 = new Vector(Angle.FromDegrees(45), 5);
            var f2 = new Vector(Angle.FromDegrees(180), 3);
            var resultingVector = new Vector(Angle.FromDegrees(81), 3.6);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void VectorsAddTest5()
        {
            var f1 = new Vector(Angle.FromDegrees(45), 5);
            var f2 = new Vector(Angle.FromDegrees(45), 3);
            var resultingVector = new Vector(Angle.FromDegrees(45), 8);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void VectorsCancelOutTest1()
        {
            var f1 = new Vector(Angle.FromDegrees(45), 2);
            var f2 = new Vector(Angle.FromDegrees(225), 2);
            var resultingVector = new Vector(Angle.FromDegrees(0), 0);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void VectorsCancelOutTest2()
        {
            var f1 = new Vector(Angle.FromDegrees(0), 2);
            var f2 = new Vector(Angle.FromDegrees(180), 2);
            var resultingVector = new Vector(Angle.FromDegrees(0), 0);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void VectorsZeroTest()
        {
            var f1 = new Vector(Angle.FromDegrees(0), 0);
            var f2 = new Vector(Angle.FromDegrees(0), 0);
            var resultingVector = new Vector(Angle.FromDegrees(0), 0);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void OneVectorZeroTest1()
        {
            var f1 = new Vector(Angle.FromDegrees(0), 0);
            var f2 = new Vector(Angle.FromDegrees(25), 10);
            var resultingVector = new Vector(Angle.FromDegrees(25), 10);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void OneVectorZeroTest2()
        {
            var f1 = new Vector(Angle.FromDegrees(68), 0);
            var f2 = new Vector(Angle.FromDegrees(120), 10);
            var resultingVector = new Vector(Angle.FromDegrees(120), 10);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void VectorsWrongOrderTest1()
        {
            var f2 = new Vector(Angle.FromDegrees(0), 6);
            var f1 = new Vector(Angle.FromDegrees(135), 4);
            var resultingVector = new Vector(Angle.FromDegrees(42), 4.2);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void VectorsWrongOrderTest2()
        {
            var f2 = new Vector(Angle.FromDegrees(45), 5);
            var f1 = new Vector(Angle.FromDegrees(270), 3);
            var resultingVector = new Vector(Angle.FromDegrees(9), 3.6);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void VectorsWrongOrderTest3()
        {
            var f2 = new Vector(Angle.FromDegrees(45), 3);
            var f1 = new Vector(Angle.FromDegrees(270), 5);
            var resultingVector = new Vector(Angle.FromDegrees(306), 3.6);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        [TestMethod]
        public void VectorsWrongOrderTest4()
        {
            var f2 = new Vector(Angle.FromDegrees(45), 5);
            var f1 = new Vector(Angle.FromDegrees(180), 3);
            var resultingVector = new Vector(Angle.FromDegrees(81), 3.6);

            VectorsWithSameAngleAreAddedCorrectly(f1, f2, resultingVector);
        }

        public void VectorsWithSameAngleAreAddedCorrectly(Vector f1, Vector f2, Vector expected)
        {
            var resultingVector = f1 + f2;

            Assert.AreEqual(Math.Round(expected.Value, 1), Math.Round(resultingVector.Value, 1));
            Assert.AreEqual(Math.Round(expected.Angle.Degree), Math.Round(resultingVector.Angle.Degree));
        }
    }
}
