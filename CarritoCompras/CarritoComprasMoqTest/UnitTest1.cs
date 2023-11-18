using CarritoCompras;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarritoComprasMoqTest
{
    [TestClass]
    public class TestCarritoCompras
    {
        private CarritoDeCompras carrito;
        private Mock<IProducto> productoMock;

        [TestInitialize]
        public void TestInitialize()
        {
            carrito = new CarritoDeCompras();
            productoMock = new Mock<IProducto>();
        }

        [TestMethod]
        public void TestAgregarProducto()
        {
            // Arrange
            productoMock.Setup(p => p.Precio).Returns(100);
            // Act
            carrito.AgregarProducto(productoMock.Object);
            // Assert
            Assert.AreEqual(100, carrito.Checkout());
        }

        [TestMethod]
        public void TestQuitarProducto()
        {
            // Arrange
            productoMock.Setup(p => p.Precio).Returns(60);
            //Act
            carrito.AgregarProducto(productoMock.Object);
            carrito.QuitarProducto(productoMock.Object);
            //Assert
            Assert.AreEqual(0, carrito.Checkout());
        }

        [TestMethod]
        public void TestCheckout()
        {
            var productoMock1 = new Mock<IProducto>();
            productoMock1.Setup(p => p.Precio).Returns(50);
            carrito.AgregarProducto(productoMock1.Object);

            var productoMock2 = new Mock<IProducto>();
            productoMock2.Setup(p => p.Precio).Returns(20);
            carrito.AgregarProducto(productoMock2.Object);

            Assert.AreEqual(70, carrito.Checkout());
            Assert.AreEqual(0, carrito.Checkout()); 
        }

    }
}
