using System;
using System.Collections.Generic;
namespace Projektarbete
{
    public class ScoreCalculator
    {
        List<Point> Points;
        List<IShape> Shapes;
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

            // Upprepa följande för alla kombinationer av en form och en punkt och summera resultaten. 
            foreach(IShape shape in Shapes)
            {
                foreach (Point point in Points)
                {
                    // Om punkten träffar formen: multiplicera formens area, och punktens PointScore.  
                    if(shape.IsPointInside(point))
                    {
                        score += (shape.CalculateArea() * ShapeScoreDictionary[shape.GetName()] * point.pointScore);
                    }
                    // Om punkten missar formen: multiplicera formens area med ShapeScore och dela sedan på fyra.
                    else
                    {
                        score += (shape.CalculateArea() * ShapeScoreDictionary[shape.GetName()] / 4);
                    }
                }
            }
            int result = Convert.ToInt32(Math.Round(score, 0, MidpointRounding.AwayFromZero));
            
            return result;
        }
    }
}

