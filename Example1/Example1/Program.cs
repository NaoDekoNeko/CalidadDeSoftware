using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public abstract class Figura
        {
            double area = 0;
            double perimetro = 0;
     
            public virtual double CalcularArea() { return area; }
            public virtual double CalcularPerimetro() { return perimetro; }
        }

        public class Cuadrado : Figura
        {
            double lado;
            public Cuadrado(double lado)
            {
                this.lado = lado;
            }
        }

        public class Circulo : Figura
        {
            double radio;
            public Circulo(double radio)
            {
                this.radio = radio;
            }
        }
    }
}
