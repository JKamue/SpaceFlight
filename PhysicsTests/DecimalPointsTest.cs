using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceFlight.Screen.Calculator;

namespace PhysicsTests
{
    [TestClass]
    public class DecimalPointsTest
    {
        [TestMethod]
        public void DecimalPointsSetCorrect1()
        {
            float test = 12345.23f;
            Assert.AreEqual("12.345,23", DecimalPoints.Add(test));
        }

        [TestMethod]
        public void DecimalPointsSetCorrect2()
        {
            float test = 345.23f;
            Assert.AreEqual("345,23", DecimalPoints.Add(test));
        }

        [TestMethod]
        public void DecimalPointsSetCorrect3()
        {
            float test = 5f;
            Assert.AreEqual("5", DecimalPoints.Add(test));
        }

        [TestMethod]
        public void DecimalPointsSetCorrect4()
        {
            float test = 512f;
            Assert.AreEqual("512", DecimalPoints.Add(test));
        }

        [TestMethod]
        public void DecimalPointsSetCorrect5()
        {
            float test = 1234567890f;
            Assert.AreEqual("1,2345679E+09", DecimalPoints.Add(test));
        }

        [TestMethod]
        public void DecimalPointsSetCorrect6()
        {
            float test = 0.10231231f;
            Assert.AreEqual("0,10231231", DecimalPoints.Add(test));
        }
    }
}
