using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;

namespace PhysicsTests
{
    [TestClass]
    public class PhysicsObjectTest
    {
        [TestMethod]
        public void CheckIfDistanceCalculatedCorrectly()
        {
            var angle = Angle.FromDegrees(0);
            var test = new PhysicsObject(new PointF(0,0), new Mass(1), new Force(angle, 5), new Acceleration(angle, 0), new Speed(angle, 0));
            
            for (int i = 0; i<20; i++)
            {
                Thread.Sleep(100);
                test.Recalculate();
            }

            Assert.AreEqual(10, test.Location.X);
        }
    }
}
