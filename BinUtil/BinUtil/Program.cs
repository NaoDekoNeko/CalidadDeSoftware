using System;
using System.Linq.Expressions;

namespace PC1Calidad
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class BinUtil
    {
        public String DecToBin(Int64 number)
        {
            var aux = number;
            String binary = "";
            while (aux > 0)
            {
                binary = (aux % 2) + binary;
                aux /= 2;
            }
            return binary;
        }

        public Int64 BinToDec(String binary)
        {
            Int64 number = 0;
            for(int i = 0; i<binary.Length; i++)
            {
                number += (Int64)(binary[i]-'0') * (Int64)(Math.Pow(2, binary.Length - i -1));
            }
            return number;
        }
    }
}
