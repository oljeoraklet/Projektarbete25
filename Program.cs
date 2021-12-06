using System;
using System.Collections.Generic;
namespace Projektarbete
{
    class Program
    {
        static void Main(string[] args)
        {
            InputHandler IH = new InputHandler(args);
            IH.MakePoints();
            IH.MakeShapes();
            IH.MakeShapeScoreDictionary();

            ScoreCalculator SC = new ScoreCalculator(IH);
            Console.WriteLine(SC.CalculateScore());
        }
    }
    
}
