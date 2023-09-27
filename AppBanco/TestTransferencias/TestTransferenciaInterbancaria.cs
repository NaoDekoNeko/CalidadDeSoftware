using System;
using AppBanco;
using Moq;
using Xunit;

namespace TestTransferencias
{
    public class TestTransferenciaInterbancaria
    {
        private Mock<IDebitar> _cuentaOrigenMock = new Mock<IDebitar>();
        private Mock<ICuentaExterna> _cuentaDestinoExternaMock = new Mock<ICuentaExterna>();
        private IAbonar _cuentaDestino;
        private ITransferencia _transferencia = new Transferencia();

        public TestTransferenciaInterbancaria()
        {
            _cuentaDestino = new AdaptadorCuenta(_cuentaDestinoExternaMock.Object);
        }

        [Fact]
        public void TestTransferenciaInterbancariaExitosa()
        {
            // Arrange
            decimal montoTransferencia = 100;

            // Act
            _transferencia.Transferir(_cuentaOrigenMock.Object, _cuentaDestino, montoTransferencia);

            // Assert
            _cuentaOrigenMock.Verify(c => c.Debitar(montoTransferencia), Times.Once());
            _cuentaDestinoExternaMock.Verify(c => c.AbonarExterno(montoTransferencia), Times.Once());
        }

        [Fact]
        public void TestTransferenciaInterbancariaFallida()
        {
            // Arrange
            decimal montoTransferencia = 100;

            // Configuramos el mock de la cuenta de origen para que lance una excepción cuando se llame al método Debitar
            _cuentaOrigenMock.Setup(c => c.Debitar(It.IsAny<decimal>())).Throws(new InvalidDebitOperationException(""));

            // Act - Assert
            var ex = Assert.Throws<InvalidTransferenceOperationException>(() =>
                _transferencia.Transferir(_cuentaOrigenMock.Object, _cuentaDestino, montoTransferencia));
        
            Assert.Equal("No se pudo debitar desde la cuenta de origen debido a falta de fondos.", ex.Message);

            // Verificamos que el método Abonar no fue llamado en la cuenta destino
            _cuentaDestinoExternaMock.Verify(c => c.AbonarExterno(It.IsAny<decimal>()), Times.Never());
        }
    }
}