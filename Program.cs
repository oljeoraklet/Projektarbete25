using System;
using System.Collections.Generic;
namespace Projektarbete
{
    class Program
    {
        static void Main(string[] args)
        {
            //string [] args2 = {"1,1,5;2,2,10;", "SQUARE,5,3,100;CIRCLE,1,1,200;", "SQUARE,5;CIRCLE,10;"};
            InputHandler IH = new InputHandler(args);
            IH.MakePoints();
            IH.MakeShapes();
            IH.MakeShapeScoreDictionary();

            ScoreCalculator SC = new ScoreCalculator(IH);
            Console.WriteLine(SC.CalculateScore());

            // Polygon Baby = new Polygon(5,3,100, "SQUARE", 4);
            // Baby.GetStats();
            

            // dotnet run "1,1,5;2,2,10;" "CIRCLE,5,3,100;CIRCLE,1,1,200;" "SQUARE,5;CIRCLE,10;"
            // dotnet run "1, 1, 5 ; 2, 2, 10" "CIRCLE, 5, 3, 100 ; CIRCLE, 1, 1, 200; " "SQUARE, 5 ; CIRCLE, 10"
            // dotnet run "1,1,5;2,2,10;", "SQUARE,5,3,100;CIRCLE,1,1,200;", "SQUARE,5;CIRCLE,10;"
        }
    }
    
}
