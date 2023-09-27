using System;

namespace AppBanco;

public class Transferencia: ITransferencia
{
    public virtual void Transferir(IDebitar origen, IAbonar destino, decimal monto)
    {
        
        if (monto < 0) throw new InvalidTransferenceOperationException("Monto a transferir debe ser positivo.");
        if (origen == null) throw new InvalidTransferenceOperationException("La cuenta de origen no existe");
        if (destino == null) throw new InvalidTransferenceOperationException("La cuenta de destino no existe");
        if (origen == destino)
            throw new InvalidTransferenceOperationException("La cuenta de origen y destino no pueden ser la misma");
        try
        {
            origen.Debitar(monto);
            destino.Abonar(monto);
        }
        catch (Exception e)
        {
            throw new InvalidTransferenceOperationException(
                "No se pudo debitar desde la cuenta de origen debido a falta de fondos.");
        }
    }
}

