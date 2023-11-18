using System;

namespace RGRGeom
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Geom
    {
        public int CircleInside(float x, float y, float radius, float centerX, float centerY)
        {
            var dist = (float)Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));
            if(radius > dist)
                return 1;
            if(radius < dist)
                return -1;
            if (Math.Abs(radius - dist)<0.1)
                return 0;
            return 2;
        }

    }
}
