using System;
namespace Projektarbete
{
    public class Circle : IShape
    {
        int perimeter;
        int centreX;
        int centreY;
        double radius;
        string shapeName;
        
        
        public Circle(int centreX, int centreY, int perimeter, string shapeName)
        {
            this.centreX = centreX;
            this.centreY = centreY;
            this.perimeter = perimeter;
            this.shapeName = shapeName;
            this.radius = perimeter / (Math.PI * 2);
        }

        public bool IsPointInside(Point targetPoint)
        {
            // If the targetpoint is further away from the middle than the radius of the circle then the point is outside
            return Math.Pow((targetPoint.x - centreX), 2) + Math.Pow((targetPoint.y - centreY), 2) <= Math.Pow(radius, 2);
        }

        public double CalculateArea()
        {
            return Math.Pow(radius, 2) * Math.PI;
        }
        public string GetName() {return shapeName;}
    
    }
}