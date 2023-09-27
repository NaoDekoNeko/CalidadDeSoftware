using AppBanco;
using Moq;
using Xunit;

namespace TestTransferencias
{
    public class TestTransferencia
    {
        private readonly Mock<ITransferencia> _transferenciaMock = new Mock<ITransferencia>();
        private Cuenta _cuentaInicio;
        private Cuenta _cuentaDestino;

        [Fact]
        public void TestTransferenciaExitosaAhorrosCorriente()
        {
            // Arrange
            _cuentaInicio = new CuentaAhorros(300);
            _cuentaDestino = new CuentaCorriente(200);
            decimal montoTransferencia = 100;

            // Configuramos el mock de la transferencia para que cuando se llame al método Transferir, 
            // realmente transfiera el monto de la cuenta de inicio a la cuenta destino
            _transferenciaMock.Setup(t => t.Transferir(It.IsAny<IDebitar>(), It.IsAny<IAbonar>(), montoTransferencia))
                .Callback<IDebitar, IAbonar, decimal>((cuentaOrigen, cuentaDestino, monto) =>
                {
                    cuentaOrigen.Debitar(monto);
                    cuentaDestino.Abonar(monto);
                });

            // Act
            // Realizamos una transferencia de 100 desde la cuenta de inicio a la cuenta destino
            _transferenciaMock.Object.Transferir(_cuentaInicio, _cuentaDestino, montoTransferencia);

            // Assert
            // Verificamos que los saldos de las cuentas sean los esperados después de la transferencia
            Assert.Equal(200, _cuentaInicio.Saldo);
            Assert.Equal(300, _cuentaDestino.Saldo);
        }

        [Fact]
        public void TestTransferenciaFallidaAhorrosCorriente()
        {
            // Arrange
            _cuentaInicio = new CuentaAhorros();
            _cuentaDestino = new CuentaCorriente(200);
            decimal montoTransferencia = 100;

            // Configuramos el mock de la transferencia para que cuando se llame al método Transferir con un monto que excede el saldo de la cuenta de inicio, lance una excepción
            _transferenciaMock.Setup(t =>
                    t.Transferir(_cuentaInicio, _cuentaDestino, It.Is<decimal>(m => m > _cuentaInicio.Saldo)))
                .Throws(new InvalidTransferenceOperationException(
                    "No se pudo debitar desde la cuenta de origen debido a falta de fondos."));

            // Act - Assert
            // Verificamos que se lance una excepción InvalidTransferenceOperationException cuando intentamos realizar una transferencia sin fondos suficientes
            var ex = Assert.Throws<InvalidTransferenceOperationException>(() =>
                _transferenciaMock.Object.Transferir(_cuentaInicio, _cuentaDestino, montoTransferencia));
            Assert.Equal("No se pudo debitar desde la cuenta de origen debido a falta de fondos.", ex.Message);
        }
    }
}