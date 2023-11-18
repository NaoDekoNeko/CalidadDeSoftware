using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using static Example1.Program;

namespace TestExample1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            Mock<Cuadrado> mock = new Mock<Cuadrado>(It.IsAny<double>());
            mock.Setup(c => c.CalcularArea()).Returns(16);

            // Act
            var resultado = mock.Object.CalcularArea();

            //Assert
            Assert.AreEqual(16, resultado);

        }
    }
}
