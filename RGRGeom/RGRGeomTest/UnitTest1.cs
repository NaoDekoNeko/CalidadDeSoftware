using Microsoft.VisualStudio.TestTools.UnitTesting;
using RGRGeom;
using System;

namespace RGRGeomTest
{
    [TestClass]
    public class GeomTestOriginCenter
    {
        private Geom g;
        private float x, y, radius, centerX, centerY;
        private int result;
        [TestInitialize]
        public void Init()
        {
            g = new Geom();
            radius = 4;
            centerX = 0;
            centerY = 0;
        }
        [TestMethod]
        public void TestInsideCircleRadius4()
        {
            // Arrange
            x = 2; y = 2;
            // Act
            result = g.CircleInside(x,y,radius,centerX,centerY);
            // Assert
            Assert.AreEqual(1,result);
        }
        [TestMethod]
        public void TestOutsideCircleRadius4()
        {
            // Arrange
            x = (float)-3.9; y = (float)2.0;
            // Act
            result = g.CircleInside(x, y, radius, centerX, centerY);
            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestInCircunferenceRadius4()
        {
            // Arrange
            x = (float)Math.Sin(0.5)*radius; y = -(float)Math.Cos(0.5) * radius;
            // Act
            result = g.CircleInside(x, y, radius, centerX, centerY);
            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
