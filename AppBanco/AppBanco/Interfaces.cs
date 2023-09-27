namespace AppBanco;

//como interfaz pues se podría implementar luego en transferencias interbancarias
public interface ITransferencia
{
    public void Transferir(IDebitar origen, IAbonar destino, decimal monto);
}
public interface IAbonar
{
    public void Abonar(decimal monto);
}

public interface IDebitar
{
    public void Debitar(decimal monto);
}

public interface ICuentaExterna
{
    void AbonarExterno(decimal monto);
    void DebitarExterno(decimal monto);
}
