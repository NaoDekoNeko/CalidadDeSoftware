using System;

namespace PruebasUnitarias
{
    public class Geometrica
    {
        static void Main(string[] args)
        {

        }

        public bool EsCuadrado(double[] x, double[] y)
        {
            double[] lados = new double[4];
            double lado;
            double[] diagonales = new double[2];

            for(int i = 0; i<4; i++)
            {
                if (i == 3)
                    lados[3] = Math.Sqrt(Math.Pow(x[3] - x[0], 2) + Math.Pow(y[3] - y[0], 2));
                else 
                    lados[i] = Math.Sqrt(Math.Pow(x[i] - x[i+1],2) + Math.Pow(y[i] - y[i+1],2));
            }

            lado = lados[0];

            for(int i = 1; i<4;i++)
            {
                if (lado != lados[i]) return false;
            }

            for(int i = 0; i<2;i++)
            {
                diagonales[i] = Math.Sqrt(Math.Pow(lados[i], 2) + Math.Pow(lados[i + 2], 2));
            }

            return  diagonales[0] == diagonales[1];
        }
    }
}
