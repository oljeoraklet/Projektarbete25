using System;
using System.Collections.Generic;
namespace Projektarbete
{
    public class ScoreCalculator
    {
        // List with all points
        List<Point> Points;
        // List with all shapes
        List<IShape> Shapes;
        // Dictionary with key SHAPE and value SHAPESCORE
        Dictionary<string, int> ShapeScoreDictionary;

        public ScoreCalculator(InputHandler IH)
        {
            this.Points = IH.Points;
            this.Shapes = IH.Shapes;
            this.ShapeScoreDictionary = IH.ShapeScoreDictionary;
        }

        public double CalculateScore()
        {

            double score = 0;
            foreach(IShape shape in Shapes)
            {
                
                foreach (Point point in Points)
                {
                    if(shape.IsPointInside(point))
                    {
                        // Console.WriteLine(shape.GetName() + " is worth "  + ShapeScoreDictionary[shape.GetName()]);
                        // Console.WriteLine("The point " + point.x + ", " + point.y + " is worth: " + point.pointScore);
                        // Console.WriteLine("The area of the shape is: " + shape.CalculateArea() + "\n");
                        // System.Console.WriteLine("Result of calculations are = " + shape.CalculateArea() * ShapeScoreDictionary[shape.GetName()] * point.pointScore + "\n");
                        score += (shape.CalculateArea() * ShapeScoreDictionary[shape.GetName()] * point.pointScore);
                    }
                    else
                    {
                        //System.Console.WriteLine(ShapeScoreDictionary[shape.GetName()]);
                        // Console.WriteLine(shape.GetName() + " is worth "  + ShapeScoreDictionary[shape.GetName()]);
                        // Console.WriteLine("The point is outside and is not worth a buck");
                        // Console.WriteLine("The area of the shape is: " + shape.CalculateArea() + "\n");
                        // System.Console.WriteLine("Result of calculations are = " + shape.CalculateArea() * ShapeScoreDictionary[shape.GetName()] / 4  +  "\n");
                        score += (shape.CalculateArea() * ShapeScoreDictionary[shape.GetName()] / 4);
                    }
                }
            }
            Console.WriteLine("The result before conversion is: " + score);
            int result = Convert.ToInt32(Math.Round(score, 0, MidpointRounding.AwayFromZero));
            Console.WriteLine("The result after conversion is: " + result + "\n");
            return result;
        }
    }
}

// Upprepa följande för alla kombinationer av en form och en punkt och summera resultaten. 
// Om punkten träffar formen: multiplicera formens area,     och punktens PointScore.  
// Om punkten missar formen: multiplicera formens area med ShapeScore och dela sedan på fyra.