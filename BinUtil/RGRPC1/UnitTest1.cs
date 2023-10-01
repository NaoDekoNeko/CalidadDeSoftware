using Microsoft.VisualStudio.TestTools.UnitTesting;
using PC1Calidad;
using System;

namespace RGRPC1
{
    [TestClass]
    public class UnitTest1
    {
        BinUtil bu;
        [TestInitialize]
        public void SetUp()
        {
            bu = new BinUtil();
        }
        [TestMethod]
        public void DecToBinTest()
        {
            Int64 n = 349;
            var res = bu.DecToBin(n);
            Assert.AreEqual("101011101", res);
        }
        [TestMethod]
        public void BinToDecTest() 
        {
            String bn = "10000001";
            var res = bu.BinToDec(bn);
            Assert.AreEqual((Int64)129, res);
        }
    }
}
