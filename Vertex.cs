using System;
namespace Projektarbete
{
    public class Vertex
    {
        public double x {get; private set; }
        public double y {get; private set; }

        public Vertex(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}