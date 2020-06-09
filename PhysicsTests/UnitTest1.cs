using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics;

namespace PhysicsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ForcesWithSameAngleAreAdded()
        {
            List<double> angles = new List<double> { 0, 20, 50, 60.12341234, 180, 210.812394823940 };

            foreach (var angle in angles)
            {
                var test = new Force(angle, 20);
                var result = test + test;
                Assert.AreEqual(angle,result.Deg);
                Assert.AreEqual(40, result.Val);
            }

            
        }
    }
}
