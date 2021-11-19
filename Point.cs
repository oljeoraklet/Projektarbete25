// Class that holds coordinates for points (both polygon vertices and pointPoints)
using System;
namespace Projektarbete
{
    public class Point
    {
        public int x {get; private set; }
        public int y {get; private set; }
        public int pointScore {get; private set; }

        public Point(int x, int y, int pointScore)
        {
            this.x = x;
            this.y = y;
            this.pointScore = pointScore;
            //Hej hej
            
        }
    }
}