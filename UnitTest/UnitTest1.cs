using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebasUnitarias;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaPrimerCuadrante()
        {
            double[] x = { 0,0,2,2}; double[] y = { 0, 2, 2, 0 };

            Geometrica g = new Geometrica();

            Assert.IsTrue(g.EsCuadrado(x, y));
        }

        [TestMethod]
        public void PruebaPrimerCuadranteNegativa()
        {
            double[] x = { 0, 0, 3, 2 }; double[] y = { 0, 1, 2, 7 };

            Geometrica g = new Geometrica();

            Assert.IsFalse(g.EsCuadrado(x, y));
        }

        [TestMethod]
        public void Prueba4Cuadrantes()
        {
            double[] x = { 2, 2, -2, -2}; double[] y = { 2, -2, -2, 2 };


            Geometrica g = new Geometrica();

            Assert.IsTrue(g.EsCuadrado(x, y));
        }

        [TestMethod]
        public void Prueba4CuadrantesNegativa()
        {
            double[] x = { 3, 2, -2, 0 }; double[] y = { 2, -5, -2, 6 };

            Geometrica g = new Geometrica();

            Assert.IsFalse(g.EsCuadrado(x, y));
        }
    }
}
