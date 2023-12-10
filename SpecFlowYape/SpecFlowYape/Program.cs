using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowYape
{
    public class Yape
    {
        public Cuenta Cuenta { get; set; }
        public Yape()
        {
            Cuenta = new Cuenta();
        }
        static void Main(string[] args)
        {
        }
    }

    public class Cuenta
    {
        public double Saldo { get; set; }
        public bool Autenticado { get; private set; }
        public Cuenta()
        {
            Autenticado = false;
            Saldo = 0;
        }
        public void Atenticar()
        {
            Autenticado = true;
        }
        public void Pagar(double monto)
        {
            if (monto < Saldo)
                Console.WriteLine("Saldo insuficiente");
            else
            {
                Saldo -= monto;
                Console.WriteLine("Pago exitoso");
            }
        }
    }
}
