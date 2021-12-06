// Class to represent all shapes except circles
using System;
namespace Projektarbete
{
    public class Polygon : IShape
    {
        int centreX; 
        int centreY; 
        double perimeter; 
        string shapeName;
        int numPoints;
        double angle; 
        double sideLength;
        double radius;
        Vertex[] vertices;
    
        public Polygon(int centreX, int centreY, int perimeter, string shapeName, int numPoints)
        {
            this.centreX = centreX;
            this.centreY = centreY;
            this.perimeter = Convert.ToDouble(perimeter);
            this.shapeName = shapeName;
            this.numPoints = numPoints;

            // Logic to calculate remainding core variables
            angle = (2 *  Math.PI) / numPoints;
            sideLength = perimeter / Convert.ToDouble(numPoints);
            radius = sideLength / (2 * Math.Sin(Math.PI / numPoints));

            // Create vertices for the polygon
            vertices = new Vertex[numPoints];
            CreateVertices();
        }
        // Returns true if point is inside of the polygon. 
        public bool IsPointInside(Point targetPoint) {
            // The sum of all the angles created between the target point and the points in the polygon
            double angleSum = 0;

            // Iterate through the points and add angles to angleSum

            for(int i = 0; i < vertices.Length; i++)
            {
                if(i == vertices.Length - 1)
                {
                    angleSum += CalculateAngleC(vertices[i], vertices[0], targetPoint);
                }
                else
                {
                    angleSum += CalculateAngleC(vertices[i], vertices[i+1], targetPoint);
                }
            }
            // Might need to be less exact
            if(angleSum < 361 && angleSum > 359)
            {
             return true;
            } 
            return false;
        }

        public string GetName(){return shapeName;}
        private void CreateVertices()
        {         
            for (int i = 0; i < numPoints; i++)
            {
                if(numPoints % 2 == 0)
                {
                    // Calculating the starting angle of the circumcircle of the polygon
                    // If the number of points are even the starting needs to be 
                    // (π / number of sides) radians in order for the shape to have a flat side on the bottom
                    angle = Math.PI / numPoints + 2 * Math.PI * i / numPoints;
                }
                else
                {
                    // For odd number-sided shapes the starting axis is just 0 radians
                    angle = 2 * Math.PI * i / numPoints;            
                }
                
                double x = Math.Round(centreX + radius * Math.Sin(angle), 2);
                double y = Math.Round(centreY + radius * Math.Cos(angle), 2);

                vertices[i] = new Vertex(x, y);
            }
        }
        public double CalculateArea()
        {
            // Calculate apothem based on sidelength and number of sides
            double area;

            double temp = (2 * Math.Tan(Math.PI / numPoints));

            double a = sideLength / temp;

            area = (numPoints * sideLength * a) / 2;

            return area;
        }

        private double CalculateAngleC(Vertex A, Vertex B, Point C)
        {

            // Calculates angle C which is the angle closest to the midpoint
            // Distance formula for coordinates - d=√((x_2-x_1)²+(y_2-y_1)²) 

            double a = Math.Pow((B.x - C.x), 2) + Math.Pow((B.y - C.y), 2); // Calculates distance of B and C
            double b = Math.Pow((A.x - C.x), 2) + Math.Pow((A.y - C.y), 2); // Calculates distance of A and C
            double c = Math.Pow((A.x - B.x), 2) + Math.Pow((A.y - B.y), 2); // Calculates distance of A and B

            double aSquared = Math.Sqrt(a);
            double bSquared = Math.Sqrt(b);

            // Cosines law - Only angleC since that's the only one relevant to the calculation
            // a² = b² + c² – 2bc cos A
            // b² = a² + c² – 2ac cos B
            // c² = a² + b² - 2ab cos C
            
            double cosC = ((a + b - c) / (2 * aSquared * bSquared));

            // Convert from radians to degrees for simplicity
            double angleC = ((Math.Acos(cosC) * 180) / Math.PI);

            return angleC;
        }
    }
}