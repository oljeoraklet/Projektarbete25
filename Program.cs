using System;
namespace Projektarbete
{
    class Program
    {
        static void Main(string[] args)
        {
            // Point point = new Point(4,5,5);
            // Console.WriteLine(point.x);
            // ShapeHandler SH = new ShapeHandler();
            // SH.MakeShapes();
            // Vertex v1 = new Vertex(0,5);
            // Vertex v2 = new Vertex(-5,0);
            // Vertex v3 = new Vertex(-5,3);

            // double angle = TestFunction(v1, v2, v3);

            // System.Console.WriteLine(angle);
            // TestLoop();

            // double test = 359.95;
            // test = Math.Round(test, 0, MidpointRounding.AwayFromZero);
            // System.Console.WriteLine(test);

            ShapeHandler sh = new ShapeHandler();

            sh.MakeShapes();
            


        }

        static public void TestLoop()
        {
            Vertex[] arr = new Vertex[4];

            arr[0] = new Vertex(0,5);
            arr[1] = new Vertex(0,0);
            arr[2] = new Vertex(-5,0);
            arr[3] = new Vertex(-5,5);

            Vertex targetPoint = new Vertex(-4.2,0.97);

            double angleSum = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                if(i == arr.Length - 1)
                {
                    angleSum += TestFunction(arr[i], arr[0], targetPoint);
                }
                else
                {
                    angleSum += TestFunction(arr[i], arr[i+1], targetPoint);
                }
            }

            System.Console.WriteLine(angleSum);

            // Hej Hej




        }
        static public double TestFunction(Vertex A, Vertex B, Vertex C)
        {
            // Distance formula for coordinates

            double a = Math.Pow((B.x - C.x), 2) + Math.Pow((B.y - C.y), 2); // Calculates distance of B and C
            double b = Math.Pow((A.x - C.x), 2) + Math.Pow((A.y - C.y), 2); // Calculates distance of A and C
            double c = Math.Pow((A.x - B.x), 2) + Math.Pow((A.y - B.y), 2); // Calculates distance of A and B

            double aSquared = Math.Sqrt(a);
            double bSquared = Math.Sqrt(b);

            // Cosines law - Only angleC since that's the only one relevant to the calculation
            
            double cosC = Math.Round(((a + b - c) / (2 * aSquared * bSquared)), 3);
            double angleC = Math.Round(((Math.Acos(cosC) * 180) / Math.PI), 0, MidpointRounding.AwayFromZero);

            return angleC;
        }
    }
    
}
