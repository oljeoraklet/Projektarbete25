using System;
using System.Collections.Generic;
using System.Globalization;
namespace Projektarbete 
{
    public class InputHandler
    {
        string pointArgs;
        string shapeArgs;
        string shapeScoreArgs;
        public List<Point> Points { get; private set; } = new List<Point>();
        public List<IShape> Shapes { get; private set; } = new List<IShape>();
        public Dictionary<string, int> ShapeScoreDictionary = new Dictionary<string, int>();
        public InputHandler(string[] args)
        {
            CheckInput(args);

            this.pointArgs = args[0].TrimEnd(';');
            this.shapeArgs = args[1].TrimEnd(';');
            this.shapeScoreArgs = args[2].TrimEnd(';');
        }
        private void CheckInput(string[] input)
        {
            if(input.Length != 3)
            {
                Console.WriteLine("Please write your input in the correct format");
                Environment.Exit(0);
            }
        }

        public void MakeShapeScoreDictionary()
        {
            try{
                string[] shapeScoresArr = shapeScoreArgs.Split(';');
                foreach (string s in shapeScoresArr)
                {
                    string[] shapeScoreArr = s.Split(',');
                    string shape = shapeScoreArr[0];
                    shape = shape.Trim();
                    Int32.TryParse(shapeScoreArr[1], out int shapeScore);
                    ShapeScoreDictionary.Add(shape, shapeScore);
                }
            }
            catch
            {
                Console.WriteLine("Your input for the shape scores is incorrect. It should follow this format: SHAPE, SHAPE_SCORE. Each point should also be separated with a ‘;’");
                Environment.Exit(0);
            }

        }
        public void MakeShapes()
        {
            try{
            string[] shapesArr = shapeArgs.Split(';');

            foreach (string s in shapesArr)
            {
                string[] shapeArr = s.Split(',');
                string shape = shapeArr[0];
                shape = shape.Trim();
                Int32.TryParse(shapeArr[1].Trim(), System.Globalization.NumberStyles.AllowLeadingSign, NumberFormatInfo.InvariantInfo, out int centreX);
                Int32.TryParse(shapeArr[2].Trim(), System.Globalization.NumberStyles.AllowLeadingSign, NumberFormatInfo.InvariantInfo, out int centreY);
                Int32.TryParse(shapeArr[3].Trim(), out int perimeter);

                // Create shapes and put in list
                switch (shape)
                {
                    case "CIRCLE":   Shapes.Add(new Circle (centreX, centreY, perimeter, shape   )); break;
                    case "TRIANGLE": Shapes.Add(new Polygon(centreX, centreY, perimeter, shape, 3)); break;
                    case "SQUARE":   Shapes.Add(new Polygon(centreX, centreY, perimeter, shape, 4)); break;
                    case "PENTAGON": Shapes.Add(new Polygon(centreX, centreY, perimeter, shape, 5)); break;
                    case "HEXAGON":  Shapes.Add(new Polygon(centreX, centreY, perimeter, shape, 6)); break;
                    case "HEPTAGON": Shapes.Add(new Polygon(centreX, centreY, perimeter, shape, 7)); break;
                    case "OCTAGON":  Shapes.Add(new Polygon(centreX, centreY, perimeter, shape, 8)); break;

                    default: 
                        Console.WriteLine("Your input for the shapes is incorrect. It should follow this format: SHAPE, X, Y, PERIMETER. Each point should also be separated with a ‘;’"); 
                        Environment.Exit(0); 
                        break;
                }
            }
            }
            catch(SystemException)
            {
                Console.WriteLine("Your input for the shapes is incorrect. It should follow this format: SHAPE, X, Y, PERIMETER. Each point should also be separated with a ‘;’"); 
                Environment.Exit(0); 
            }
        }

        public void MakePoints()
        {
            try
            {
                string[] pointsArr = pointArgs.Split(';');

                foreach (string s in pointsArr)
                {            
                    string[] pointArr = s.Split(',');

                    Int32.TryParse(pointArr[0].Trim(), System.Globalization.NumberStyles.AllowLeadingSign, NumberFormatInfo.InvariantInfo, out int x);
                    Int32.TryParse(pointArr[1].Trim(), System.Globalization.NumberStyles.AllowLeadingSign, NumberFormatInfo.InvariantInfo, out int y);
                    Int32.TryParse(pointArr[2], out int pointScore);

                    Points.Add(new Point(x, y, pointScore));
                }
            
            }
            catch (System.Exception)
            {
                Console.WriteLine("Your input for the points is incorrect. It should follow this format: X, Y, SCORE. Each point should also be separated with a ‘;’");
                Environment.Exit(0);
            }
        }
    }
}