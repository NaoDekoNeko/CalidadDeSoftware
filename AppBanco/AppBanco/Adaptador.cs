namespace AppBanco;

public class AdaptadorCuenta : IAbonar, IDebitar
{
    private ICuentaExterna CuentaExterna { get; }

    public AdaptadorCuenta(ICuentaExterna cuentaExterna)
    {
        CuentaExterna = cuentaExterna;
    }

    public void Abonar(decimal monto)
    {
        CuentaExterna.AbonarExterno(monto);
    }

    public void Debitar(decimal monto)
    {
        CuentaExterna.DebitarExterno(monto);
    }
}