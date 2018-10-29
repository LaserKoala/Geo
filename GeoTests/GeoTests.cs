using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Device.Location;
using Geo;

namespace GeoTests
{
    [TestClass]
    public class GeoTests
    {
        [TestMethod]
        public void CorrectDistanceCalculation_Test()
        {
            var expected = 891.9;
            var actual = GeoPoint.GetDistance(new GeoPoint(50, 3), new GeoPoint(58, 4));
            Assert.AreEqual(expected, actual, 0.1);
        }
        [TestMethod]
        public void CorrectDistanceCalculation_Test1()
        {
            var expected = 111;
            var actual = GeoPoint.GetDistance(new GeoPoint(0, 0), new GeoPoint(0, 1));
            Assert.AreEqual(expected, actual, 1);
        }
        [TestMethod]
        public void CorrectDistanceCalculation_Test2()
        {
            var expected = 0.2;
            var actual = GeoPoint.GetDistance(new GeoPoint(89.9, 0), new GeoPoint(89.9, 1));
            Assert.AreEqual(expected, actual, 1);
        }


        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void ArgumentOutOfRange_FailTest()
        {
            GeoPoint.GetDistance(new GeoPoint(505, -343), new GeoPoint(4334, 32313));
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void NullArgument_FailTest()
        {
            GeoPoint.GetDistance(new GeoPoint(0,0), null);
            GeoPoint.GetDistance(null, new GeoPoint(0, 0));
            GeoPoint.GetDistance(null, null);
        }

    }
}
