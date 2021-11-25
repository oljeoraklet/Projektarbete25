// Class to represent all shapes except circles
using System;
namespace Projektarbete
{
    public class Polygon : IShape
    {
        int centreX; // Centre coordinate in the x-axis from where the polygon is drawn
        int centreY; // Centre coordinate in the y-axis from where the polygon is drawn
        double perimeter; // Radius of the polygon
        string shapeName;
        int numPoints;
        double angle; 
        double sideLength;
        double radius;
        Vertex[] vertices; //Coordinates for vertices in the x-axis
    

        // Constructor which creates a polygon given a number of points, a radius and a centre X and Y position.
        public Polygon(int centreX, int centreY, int perimeter, string shapeName, int numPoints)
        {
            this.centreX = centreX;
            this.centreY = centreY;
            this.perimeter = Convert.ToDouble(perimeter);
            this.shapeName = shapeName;
            this.numPoints = numPoints;

            // Calculate numbers needed for the calculations below
            angle = (2 *  Math.PI) / numPoints;
            sideLength = perimeter / Convert.ToDouble(numPoints);
            radius = sideLength / (2 * Math.Sin(Math.PI / numPoints));

            // Make of vertices for the polygon
            vertices = new Vertex[numPoints];
            GetVertices();
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

        // Calculates the vertices of a polygon and places x and y coordinates in their respective arrays.
        private void GetVertices()
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

                // if(numPoints > 6)
                // {
                    
                //     System.Console.WriteLine($"Centre X{i} of {shapeName} = {centreX}");
                //     System.Console.WriteLine($"Centre Y{i} of {shapeName} = {centreY} \n");
                //     System.Console.WriteLine($"X{i} of {shapeName} = {x}");
                //     System.Console.WriteLine($"Y{i} of {shapeName} = {y} \n");
                // }

                vertices[i] = new Vertex(x, y);
            }
        }

        public void GetStats()
        {
            System.Console.WriteLine("Area = " + CalculateArea());
            System.Console.WriteLine("Angle = " + (Math.Round(angle  * 180 / Math.PI)));
            System.Console.WriteLine("Number of points = " + numPoints);
            System.Console.WriteLine("Shapename = " + shapeName);
            System.Console.WriteLine("Sidelength = " + sideLength);
            System.Console.WriteLine("Radius = " + radius);
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

            // System.Console.WriteLine($"Angle C in {shapeName} before conversion is {((Math.Acos(cosC) * 180) / Math.PI)}");

            // Convert from radians to degrees for simplicity
            double angleC = ((Math.Acos(cosC) * 180) / Math.PI);

            return angleC;
        }
    }
}