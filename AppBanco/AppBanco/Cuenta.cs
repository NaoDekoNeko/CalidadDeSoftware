namespace AppBanco;

public abstract class Cuenta:IAbonar,IDebitar
{
    protected Cuenta(decimal saldo)
    {
        Saldo = saldo;
    }

    protected Cuenta()
    {
        Saldo = 0;
    }

    public decimal Saldo { get; protected set; }
        
    public virtual void Abonar(decimal monto)
    {
        if (monto < 0) throw new InvalidCreditOperationException("El abono debe ser positivo.");
        Saldo += monto;
    }

    public abstract void Debitar(decimal monto);
}

public class CuentaAhorros : Cuenta
{
    public CuentaAhorros(decimal saldo) : base(saldo)
    {
    }

    public CuentaAhorros()
    {
    }
    
    public override void Debitar(decimal monto)
    {
        if (monto < 0) throw new InvalidDebitOperationException("El débito debe ser positivo.");
        if (monto > Saldo)
            throw new InvalidDebitOperationException("El importe excede el saldo disponible.");
        Saldo -= monto;
    }
}

public class CuentaCorriente : Cuenta
{
    public decimal SobregiroAutorizado { get; }

    public CuentaCorriente(decimal saldo):base(saldo)
    {
        SobregiroAutorizado = Saldo*(decimal)0.10;
    }

    public CuentaCorriente()
    {
        SobregiroAutorizado = 0;
    }
    public override void Debitar(decimal monto)
    {
        if (monto < 0) throw new InvalidDebitOperationException("El débito debe ser positivo.");
        if (monto > Saldo + SobregiroAutorizado)
            throw new InvalidDebitOperationException("El importe excede la linea de credito.");
        Saldo -= monto;
    }
}