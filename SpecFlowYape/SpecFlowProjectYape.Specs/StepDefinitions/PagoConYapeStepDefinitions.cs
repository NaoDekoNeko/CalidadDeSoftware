using SpecFlowYape;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectYape.Specs.StepDefinitions
{
    [Binding]
    public class PagoConYapeStepDefinitions
    {
        Yape yape = new Yape();
        StringWriter stringWriter = new StringWriter();
        [Given(@"estoy autenticado en la aplicación con una cuenta Yape vinculada")]
        public void GivenEstoyAutenticadoEnLaAplicacionConUnaCuentaYapeVinculada()
        {
            yape.Cuenta.Atenticar();
            yape.Cuenta.Autenticado.Should().Be(true);
        }

        [When(@"sin saldo suficiente confirmo el monto a pagar de (.*)")]
        public void WhenSeleccionoElMontoAPagarDe(double p0)
        {
            Console.SetOut(stringWriter);
            yape.Cuenta.Pagar(p0);
        }

        [Then(@"veo un mensaje de error indicando que no hay saldo suficiente")]
        public void ThenVeoUnMensajeDeErrorIndicandoQueNoHaySaldoSuficiente()
        {
            stringWriter.ToString().Should().Contain("Saldo insuficiente");
        }
    }
}
