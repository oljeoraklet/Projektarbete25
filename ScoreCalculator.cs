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
            int round = 1;
            double score = 0;
            foreach(IShape shape in Shapes)
            {
                foreach (Point point in Points)
                {
                    if(shape.IsPointInside(point))
                    {
                        score += (shape.CalculateArea() * ShapeScoreDictionary[shape.GetName()] * point.pointScore);
                        System.Console.WriteLine($"Runda: {round} \n Score = {score} \n Area =  + {shape.CalculateArea()} \n PointScore =  {point.pointScore} \n Shape = {ShapeScoreDictionary[shape.GetName()]}\n");
                    }
                    else
                    {
                        score += (shape.CalculateArea() * ShapeScoreDictionary[shape.GetName()]) / 4;
                        System.Console.WriteLine($"Runda: {round} \n Score = {score} \n Area =  + {shape.CalculateArea()} \n Shape = {ShapeScoreDictionary[shape.GetName()]}\n");
                    }
                    round++;
                }
            }
            int result = Convert.ToInt32(Math.Round(score, 0, MidpointRounding.AwayFromZero));
            return result;
        }
    }
}

// Upprepa följande för alla kombinationer av en form och en punkt och summera resultaten. 
// Om punkten träffar formen: multiplicera formens area, ShapeScore och punktens PointScore.  
// Om punkten missar formen: multiplicera formens area med ShapeScore och dela sedan på fyra.